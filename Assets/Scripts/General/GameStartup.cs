using UnityEngine;

namespace Assets.Scripts
{
    public class GameStartup : MonoBehaviour
    {
        [SerializeField] private City _city;
        [SerializeField][Range(10, 100)] private float _startingSpeed;

        [Header("UI")]
        [SerializeField] private LifeCounter _lifeCounter;
        [SerializeField] private ChargeCounter _chargeCounter;
        
        private ChunkGenerator _chunkGenerator;
        private EntitySpawner _entitySpawner;

        private void Awake()
        {
            _entitySpawner = GetComponentInChildren<EntitySpawner>();
            _chunkGenerator = GetComponentInChildren<ChunkGenerator>();
        }

        private void Start()
        {
            Container chunkContainer = ContainerService.GetCreatedContainer("Chunks", _city.transform);
            Container entityContainer = ContainerService.GetCreatedContainer("Entities", _city.transform);
            SpeedService.SetStartSpeed(_startingSpeed);

            _chunkGenerator.EnableChunks(chunkContainer, 10);
            _entitySpawner.EnablePlayerCamera(entityContainer);
            _entitySpawner.EnableQuadcopter(entityContainer, _lifeCounter, _chargeCounter);
            _entitySpawner.EnableCarTraffic(entityContainer);
            _entitySpawner.EnableAggressiveBirds(entityContainer);
            _entitySpawner.EnableNetGuys(entityContainer, _chunkGenerator);
            _entitySpawner.EnableBatteries(entityContainer);
        }
    }
}