using UnityEngine;

namespace Assets.Scripts
{
    public delegate void SpawnMethod();

    public class ChunkGenerator : MonoBehaviour
    {
        [SerializeField] private ChunkConfig _chunkConfig;
        [Space(30)]
        [SerializeField] [Range(1, 100)] private int _startableChunksAmount;

        private WayMatrix _wayMatrix = new WayMatrix();
        private Container _chunkContainer;
        private Pool<Chunk> _chunksPool;
        private Chunk _lastSpawnedChunk;
        private EntitySpawner _entitySpawner;

        public void Init(City city, EntitySpawner entitySpawner)
        {
            _entitySpawner = entitySpawner;
            _chunkContainer = ContainerService.GetCreatedContainer("Chunks", city.transform, _wayMatrix.GetPosition(MatrixPosition.Center));
            ChunkFactory chunkFactory = new ChunkFactory(_chunkConfig, _chunkContainer, SpawnChunk);
            _chunksPool = new Pool<Chunk>(chunkFactory, _chunkContainer, _chunkConfig.PrefabsCount);
            GenerateStartableChunks(_startableChunksAmount);
        }

        private void GenerateStartableChunks(int amount)
        {
            _lastSpawnedChunk = _chunksPool.Get(_wayMatrix.GetPosition(MatrixPosition.Center));

            for (int i = -1; i < amount; i++)
                _lastSpawnedChunk = _chunksPool.Get(_lastSpawnedChunk.ConnectPosition);
        }

        public Chunk GetGeneratedChunk(Vector3 position)
        {
            Chunk spawnedChunk =  _chunksPool.Get(position);
            spawnedChunk.SetWindows(_entitySpawner);
            _lastSpawnedChunk = spawnedChunk;
            return spawnedChunk;
        }

        public void SpawnChunk() => GetGeneratedChunk(_lastSpawnedChunk.ConnectPosition);
    }
}