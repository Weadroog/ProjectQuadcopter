using System;
using UnityEngine;

namespace Assets.Scripts
{
    public class ChunkGenerator : MonoBehaviour
    {
        public event Action<Chunk> OnSpawnChunk;

        [SerializeField] private ChunkDatabase _chunkDatabase;
        [Space(30)]
        [SerializeField] [Range(1, 100)] private int _startableChunksAmount;

        private WayMatrix _wayMatrix = new WayMatrix();
        private Container _chunkContainer;
        private Pool<Chunk> _chunksPool;
        private Chunk _lastSpawnedChunk;

        public void EnableChunks(Container chunkContainer)
        {
            _chunkContainer = chunkContainer;
            ChunkFactory chunkFactory = new ChunkFactory(_chunkDatabase, _chunkContainer, SpawnChunk);
            _chunksPool = new Pool<Chunk>(chunkFactory, _chunkContainer, _chunkDatabase.PrefabsCount);
            SpawnStartableChunks(_startableChunksAmount);
        }

        private void SpawnStartableChunks(int amount)
        {
            _lastSpawnedChunk = _chunksPool.Get(_wayMatrix.GetPosition(MatrixPosition.Center));

            for (int i = -1; i < amount; i++)
                _lastSpawnedChunk = _chunksPool.Get(_lastSpawnedChunk.ConnectPosition);
        }

        public void SpawnChunk()
        {
            Chunk spawnedChunk = _chunksPool.Get(_lastSpawnedChunk.ConnectPosition);
            _lastSpawnedChunk = spawnedChunk;
            OnSpawnChunk?.Invoke(spawnedChunk);
        }
    }
}