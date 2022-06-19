using System;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts
{
    public class GameStartup : MonoBehaviour
    {
        [SerializeField] private City _city;
        [SerializeField][Range(10, 100)] private float _startableSpeed;

        private ChunkGenerator _chunkGenerator;
        private EntitySpawner _entitySpawner;
        private Button _tapToStartButton;
        private SpeedService _speedService;

        private void Awake()
        {
            _entitySpawner = GetComponentInChildren<EntitySpawner>();
            _chunkGenerator = GetComponentInChildren<ChunkGenerator>();
            _speedService = GetComponentInChildren<SpeedService>();
            _tapToStartButton = FindObjectOfType<TapToStart>().GetComponent<Button>();
        }

        private void Start()
        {
            Container chunkContainer = ContainerService.GetCreatedContainer("Chunks", _city.transform);
            Container entityContainer = ContainerService.GetCreatedContainer("Entities", _city.transform);
            _speedService.SetStartableSpeed(_startableSpeed);
            _chunkGenerator.EnableChunks(chunkContainer);
            _entitySpawner.EnablePlayerCamera(entityContainer);
            _entitySpawner.EnableQuadcopter(entityContainer).GetComponent<Lifer>().OnDeath += Stop;
            _entitySpawner.EnableCarTraffic(entityContainer);
            _entitySpawner.EnableAggressiveBirds(entityContainer);
            _entitySpawner.EnableNetGuys(entityContainer, _chunkGenerator);
            _entitySpawner.EnableBatteries(entityContainer);
            _speedService.enabled = false;
            _tapToStartButton.onClick.AddListener(Startup);
        }

        private void Stop()
        {
            _speedService.enabled = false;
            _entitySpawner.StopAllCoroutines();
        }

        private void Startup()
        {
            _speedService.enabled = true;
            _tapToStartButton.gameObject.SetActive(false);

            if (_entitySpawner.IsEnabled<Car>())
                _entitySpawner.SpawnCars();

            if (_entitySpawner.IsEnabled<AggressiveBird>())
                _entitySpawner.SpawnAggressiveBirds();
        }
    }
}