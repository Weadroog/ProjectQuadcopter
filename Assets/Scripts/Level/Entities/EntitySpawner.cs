﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;
using General;
using Services;
using Ads;
using Chunk;
using UI;
using Components;
using Random = UnityEngine.Random;

namespace Entities
{
    public class EntitySpawner : MonoBehaviour
    {
        private Dictionary<Type, IPool> _pools = new();
        private readonly WayMatrix _wayMatrix = new();
        private ChunkGenerator _chunkGenerator;
        private Quadcopter _quadcopter;
        private bool _isClientRequested;
        private Deliverer _deliverer;
        private Pizza _pizza;
        private PizzaGuy _pizzaGuy;

        [SerializeField, BoxGroup("Configurations")] private QuadcopterConfig _quadcopterConfig;
        [SerializeField, BoxGroup("Configurations")] private BirdConfig _birdConfig;
        [SerializeField, BoxGroup("Configurations")] private CarConfig _carConfig;
        [SerializeField, BoxGroup("Configurations")] private NetGuyConfig _netGuyConfig;
        [SerializeField, BoxGroup("Configurations")] private BatteryConfig _batteryConfig;
        [SerializeField, BoxGroup("Configurations")] private ClientConfig _clientConfig;
        [SerializeField, BoxGroup("Configurations")] private PizzaGuyConfig _pizzeriaGuyConfig;
        [SerializeField, BoxGroup("Configurations")] private PizzaConfig _pizzaConfig;

        [SerializeField, Range(0, 100), BoxGroup("SpawnDensity")] private int _birdsDensity;
        [SerializeField, Range(0, 100), BoxGroup("SpawnDensity")] private int _carsDensity;
        [SerializeField, Range(0, 100), BoxGroup("SpawnDensity")] private int _netGuysDensity;

        [SerializeField][Range(0, 1000)] private int _spawnDistance;

        private void Awake() => _chunkGenerator = FindObjectOfType<ChunkGenerator>();

        private void OnEnable()
        {
            _chunkGenerator.OnSpawnChunk += SettleWindows;
            GlobalSpeedService.OnStartup += SpawnCars;
            GlobalSpeedService.OnStartup += SpawnBirds;
            GlobalSpeedService.OnStop += StopAllCoroutines;
        }

        public Quadcopter EnableQuadcopter(Container entityContainer, DefeatPanel defeatPanel)
        {
            LifeDisplayer lifeCounter = FindObjectOfType<LifeDisplayer>();
            AdsRewardedButton rewardedButton = FindObjectOfType<AdsRewardedButton>();

            _quadcopter = GetCreatedEntity(new QuadcopterFactory(_quadcopterConfig, entityContainer, lifeCounter, defeatPanel, rewardedButton));
            _deliverer = _quadcopter.GetComponent<Deliverer>();
            return _quadcopter;
        }

        public void EnableCarTraffic(Container entityContainer)
        {
            _pools[typeof(Car)] = new Pool<Car>(new CarFactory(_carConfig), entityContainer, 10);
        }

        public void EnableBirds(Container entityContainer)
        {
            _pools[typeof(Bird)] = new Pool<Bird>(new BirdFactory(_birdConfig), entityContainer, 10);
        }

        public void EnableNetGuys(Container entityContainer)
        {
            _pools[typeof(NetGuy)] = new Pool<NetGuy>(new NetGuyFactory(_netGuyConfig), entityContainer, 10);
        }

        public void EnableBatteries(Container entityContainer)
        {
            _pools[typeof(Battery)] = new Pool<Battery>(new BatteryFactory(_batteryConfig), entityContainer, 3);
            _quadcopter.GetComponent<Charger>().OnDecreased += SpawnBattery;
        }

        public void EnableDelivery(Container entityContainer, ChunkGenerator chunkGenerator)
        {
            _deliverer.OnPizzeriaRequested += _chunkGenerator.RequestPizzeria;
            EnablePizza(entityContainer);
            EnablePizzaGuy(entityContainer, chunkGenerator);
            EnableClient(entityContainer);
        }

        private void EnablePizza(Container entityContainer)
        {
            _pizza = new PizzaFactory(_pizzaConfig, _deliverer).GetCreated();
            _pizza.transform.SetParent(entityContainer.transform);
        }

        private void EnablePizzaGuy(Container entityContainer, ChunkGenerator chunkGenerator)
        {
            _pizzaGuy = new PizzaGuyFactory(_pizzeriaGuyConfig, _deliverer, _pizza, _quadcopter).GetCreated();
            _pizzaGuy.transform.SetParent(entityContainer.transform);
            chunkGenerator.OnPizzeriaSpawned += SpawnPizzaGuy;
        }

        private void EnableClient(Container entityContainer)
        {
            _pools[typeof(Client)] = new Pool<Client>(new ClientFactory(_clientConfig, _deliverer), entityContainer, 10);
            _deliverer.OnPizzaGrabbed += () => _isClientRequested = true;
            _deliverer.OnDeliverySequenceFailed += () => _isClientRequested = false;
        }

        private void SpawnPizzaGuy(PizzaDispensePoint dispensePoint)
        {
            PizzaGuy pizzeriaGuy = _pizzaGuy;
            pizzeriaGuy.gameObject.SetActive(true);
            pizzeriaGuy.transform.position = (dispensePoint.transform.position);
            pizzeriaGuy.transform.eulerAngles = Vector3.up * (pizzeriaGuy.transform.position.x < 0 ? 180 : 0);
        }

        private IEnumerator CarSpawning(int line)
        {
            float delay = 0.5f; 
            float maxDistance = 15f;
            float minDistance = 5f;
            float previousHalfSize = 0;
            float offset = 1.5f;

            Vector3 instancePosition = new Vector3(-250f, -15f, 1000f);
            Vector3 spawnPosition = _wayMatrix.GetPositionByArrayCoordinates(new Vector2Int(line, WayMatrix.Height - 1)) + Vector3.down * offset + Vector3.forward * _spawnDistance;

            while (true)
            {
                if (_carsDensity > Random.Range(0, 100))
                {
                    Car car = GetPool<Car>().Get(instancePosition);
                    if (car.CarColorChanger != null) car.CarColorChanger.ChangeColorRandom();

                    float distanceBetweenCars = Random.Range(minDistance, maxDistance);
                    float speed = GlobalSpeedService.Speed + _carConfig.SelfSpeed;
                    float halfSize = car.Size / 2;
                    delay = (Mathf.Sqrt(speed * speed + 2 * GlobalSpeedService.Acceleration * (distanceBetweenCars + halfSize + previousHalfSize)) - speed) / GlobalSpeedService.Acceleration;
                    previousHalfSize = halfSize;

                    yield return new WaitForSeconds(delay);

                    car.transform.position = spawnPosition;
                }
                else yield return new WaitForSeconds(delay);
            }
        }

        public void SpawnCars()
        {
            if (IsEnabled<Car>())
            {
                for (int line = 0; line < WayMatrix.Width; line++)
                    StartCoroutine(CarSpawning(line));
            }
        }

        private IEnumerator BirdsSpawning(int line, int row)
        {
            float delay = 0.5f;
            float maxDistance = 5f;
            float minDistance = 2f;

            while (true)
            {
                Vector3 position = _wayMatrix.GetPositionByArrayCoordinates(new Vector2Int(line, row));

                if (_birdsDensity > Random.Range(0, 100))
                {
                    GetPool<Bird>().Get(position + Vector3.forward * _spawnDistance);
                    float speed = GlobalSpeedService.Speed + _birdConfig.SelfSpeed;
                    float distanceBetweenBirds = Random.Range(minDistance, maxDistance);
                    float acceleration = GlobalSpeedService.Acceleration;

                    delay = (Mathf.Sqrt(speed * speed + 2 * acceleration * (distanceBetweenBirds)) - speed) / acceleration;

                    yield return new WaitForSeconds(delay);
                }

                yield return new WaitForSeconds(delay);
            }
        }

        public void SpawnBirds()
        {
            if (IsEnabled<Bird>())
            {
                for (int row = 0; row < 3; row++)
                    for (int i = 0; i < WayMatrix.Width; i++)
                        StartCoroutine(BirdsSpawning(i, row));
            } 
        }

        private void SettleWindows(IEnumerable<Window> windows)
        {
            foreach (Window window in windows)
            {
                if (Random.Range(0, 100) > _netGuysDensity)
                {
                    window.Close();
                    continue;
                }

                if (IsEnabled<Client>() && _isClientRequested)
                {
                    Client client = GetPool<Client>().Get(window.GetSpawnPoint());
                    client.GetComponentInChildren<Animator>().SetFloat(AnimationService.Parameters.Side, Mathf.Clamp(client.transform.position.x, -1, 1));
                    _isClientRequested = false;
                }
                else if (IsEnabled<NetGuy>())
                    GetPool<NetGuy>().Get(window.GetSpawnPoint());

                window.Open();
            }
        }

        private void SpawnBattery()
        {
            GetPool<Battery>().Get(_wayMatrix.GetRandomPosition() + Vector3.forward * WayMatrix.Horizon);
        }

        public Pool<T> GetPool<T>() where T : Entity => _pools[typeof(T)] as Pool<T>;

        public bool IsEnabled<T>() where T : Entity => _pools.ContainsKey(typeof(T));

        private E GetCreatedEntity<E>(IFactory<E> entityFactory) where E : Entity => entityFactory.GetCreated();

        private void OnDisable()
        {
            _chunkGenerator.OnSpawnChunk -= SettleWindows;
            _chunkGenerator.OnSpawnChunk += SettleWindows;
            GlobalSpeedService.OnStartup += SpawnCars;
            GlobalSpeedService.OnStartup += SpawnBirds;
            GlobalSpeedService.OnStop += StopAllCoroutines;
            _deliverer.OnPizzeriaRequested -= _chunkGenerator.RequestPizzeria;
        }
    }
}
