using UnityEngine;

namespace Assets.Scripts
{
    public class GameStartup : MonoBehaviour
    {
        [Header("Configurations")]
        [SerializeField] private City _city;
        [SerializeField][Range(10, 100)] private float _startSpeed;

        private EntitySpawner _entitySpawner;
        private ChunkGenerator _chunkGenerator;

        private void Awake()
        {
            _entitySpawner = GetComponentInChildren<EntitySpawner>();
            _chunkGenerator = GetComponentInChildren<ChunkGenerator>();
        }

        private void Start()
        {
            SpeedService.SetStartSpeed(_startSpeed);
            _entitySpawner.Init(_city);
            _entitySpawner.EnablePlayerCamera();
            _entitySpawner.EnableQuadcopter();
            _entitySpawner.EnableCarTraffic();
            _entitySpawner.EnableAggressiveBirds();
            _chunkGenerator.Init(_city, _entitySpawner);

        }
    }
}