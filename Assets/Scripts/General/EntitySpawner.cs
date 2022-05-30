using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Assets.Scripts
{
    public class EntitySpawner : MonoBehaviour
    {
        private Dictionary<Type, IPool> _pools = new Dictionary<Type, IPool>();
        private WayMatrix _wayMatrix = new WayMatrix();
        private Quadcopter _quadcopter;

        [Header("Configurations")]
        [SerializeField] private QuadcopterConfig _quadcopterConfig;
        [SerializeField] private PlayerCameraConfig _playerCameraConfig;
        [SerializeField] private AggressiveBirdConfig _aggressiveBirdConfig;
        [SerializeField] private CarConfig _carConfig;
        [SerializeField] private ClotheslineConfig _clotheslineConfig;
        [SerializeField] private NetGuyConfig _netGuyConfig;
        [SerializeField] private BatteryConfig _batteryConfig;

        [Header("SpawnDensity")]
        [SerializeField] [Range(0, 100)] private int _aggressiveBirdDensity;
        [SerializeField] [Range(0, 100)] private int _carDensity;
        [SerializeField] [Range(0, 100)] private int _clothesLineDensity;
        [SerializeField] [Range(0, 100)] private int _netGuyDensity;

        public void EnablePlayerCamera(Container entityContainer)
        {
            GetCreatedEntity(new PlayerCameraFactory(_playerCameraConfig, entityContainer, _wayMatrix.GetPosition(MatrixPosition.Center)));
        }

        public void EnableQuadcopter(Container entityContainer, LifeCounter lifeCounter, ChargeCounter chargeCounter)
        {
            _quadcopter = GetCreatedEntity(new QuadcopterFactory(_quadcopterConfig, entityContainer, lifeCounter, chargeCounter));
        } 

        public void EnableCarTraffic(Container entityContainer)
        {
            _pools[typeof(Car)] = new Pool<Car>(new CarFactory(_carConfig), entityContainer, 10);

            for (int i = 0; i < WayMatrix.Width; i++)
            {
                StartCoroutine(SpawnCars(i));
            }
        }

        public void EnableAggressiveBirds(Container entityContainer)
        {
            _pools[typeof(AggressiveBird)] = new Pool<AggressiveBird>(new AggressiveBirdFactory(_aggressiveBirdConfig), entityContainer, 10);

            for (int row = 0; row < 3; row++)
            {

                for (int i = 0; i < WayMatrix.Width; i++)
                {
                    StartCoroutine(SpawnAggressiveBirds(i, row));
                }
            }
        }

        public void EnableNetGuys(Container entityContainer, ChunkGenerator chunkGenerator)
        {
            chunkGenerator.OnSpawnChunk += SpawnNetGuy; 
            _pools[typeof(NetGuy)] = new Pool<NetGuy>(new NetGuyFactory(_netGuyConfig), entityContainer, 10);
        }

        public void EnableBatteries(Container entityContainer)
        {
            _pools[typeof(Battery)] = new Pool<Battery>(new BatteryFactory(_batteryConfig), entityContainer, 3);
            _quadcopter.GetComponent<Charger>().OnDecreased += SpawnBattery;
        }

        private IEnumerator SpawnCars(int line)
        {
            float horizon = 200f;
            float startSpeed = SpeedService.Speed;

            while (true)
            {
                Vector3 position = _wayMatrix.GetPositionByArrayCoordinates(new Vector2Int(line, WayMatrix.Height - 1));

                if (_carDensity > Random.Range(0, 100))
                {
                    GetPool<Car>().Get(position + Vector3.forward * horizon);
                }

                yield return new WaitForSeconds(Random.Range(0.15f * startSpeed / SpeedService.Speed, 0.5f * startSpeed / SpeedService.Speed));
            }
        }

        private IEnumerator SpawnAggressiveBirds(int line, int row)
        {
            float horizon = 200f;
            float startSpeed = SpeedService.Speed;

            while (true)
            {
                Vector3 position = _wayMatrix.GetPositionByArrayCoordinates(new Vector2Int(line, row));

                if (_aggressiveBirdDensity > Random.Range(0, 100))
                {
                    GetPool<AggressiveBird>().Get(position + Vector3.forward * horizon);
                }

                yield return new WaitForSeconds(Random.Range(0.15f * startSpeed / SpeedService.Speed, 0.5f * startSpeed / SpeedService.Speed));
            }
        }

        private void SpawnNetGuy(Chunk chunk)
        {
            IEnumerable<Window> windows = chunk.GetWindows();

            foreach (Window window in windows)
            {
                if (Random.Range(0, 100) > _netGuyDensity)
                {
                    window.Close();
                    continue;
                }

                GetPool<NetGuy>().Get(window.SpawnPoint.transform.position);
                window.Open();
            }
        }

        private void SpawnBattery()
        {
            GetPool<Battery>().Get(_wayMatrix.GetPosition(MatrixPosition.Center) + Vector3.forward * 200);
        }

        public Pool<T> GetPool<T>() where T : Actor => _pools[typeof(T)] as Pool<T>;

        private E GetCreatedEntity<E>(IFactory<E> entityFactory) where E : Entity => entityFactory.GetCreated();

        private void OnDestroy() => StopAllCoroutines();
    }
}
