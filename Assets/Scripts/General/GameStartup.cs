using UnityEngine;
using UnityEngine.UI;
using Services;
using UI;
using Chunk;
using Level;
using Entities;

namespace General
{
    public class GameStartup : MonoBehaviour
    {
        [SerializeField] private City _city;

        private ChunkGenerator _chunkGenerator;
        private EntitySpawner _entitySpawner;
        private Button _tapToStartButton;

        private void Awake()
        {
            _entitySpawner = GetComponentInChildren<EntitySpawner>();
            _chunkGenerator = GetComponentInChildren<ChunkGenerator>();
            _tapToStartButton = FindObjectOfType<TapToStart>().GetComponent<Button>();
        }

        private void Start()
        {
            Container chunkContainer = ContainerService.GetCreatedContainer("Chunks", _city.transform);
            Container entityContainer = ContainerService.GetCreatedContainer("Entities", _city.transform);
            _chunkGenerator.EnableChunks(chunkContainer);
            _entitySpawner.EnableQuadcopter(entityContainer);
            _entitySpawner.EnableCarTraffic(entityContainer);
            _entitySpawner.EnableAggressiveBirds(entityContainer);
            _entitySpawner.EnableNetGuys(entityContainer);
            //_entitySpawner.EnableBatteries(entityContainer);
            //_entitySpawner.EnableDelivery(entityContainer, _chunkGenerator);
            GlobalSpeedService.Stop();
            _tapToStartButton.onClick.AddListener(GlobalSpeedService.Startup);
        }
    }
}