﻿using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    public delegate void SpawnMethod();

    public class ChunkGenerator : MonoBehaviour
    {
        [SerializeField] private List<Chunk> _chunkPrefabs;
        [Space(30)]
        [SerializeField] [Range(1, 100)] private int _startableChunksAmount;

        private WayMatrix _wayMatrix;
        private Container _chunkContainer;
        private Pool<Chunk> _chunksPool;
        private Chunk _lastSpawnedChunk;
        private EntitySpawner _entitySpawner;

        public void Init(City city, WayMatrix wayMatrix, EntitySpawner entitySpawner)
        {
            _wayMatrix = wayMatrix;
            _entitySpawner = entitySpawner;
            _chunkContainer = ContainerService.GetCreatedContainer("Chunks", city.transform, _wayMatrix.Center);
            ChunkFactory chunkFactory = new ChunkFactory(_chunkPrefabs, _chunkContainer, wayMatrix, SpawnChunk);
            _chunksPool = new Pool<Chunk>(chunkFactory, _chunkContainer, _chunkPrefabs.Count);
            GenerateStartableChunks(_startableChunksAmount);
        }

        private void GenerateStartableChunks(int amount)
        {
            _lastSpawnedChunk = GetGeneratedChunk(_wayMatrix.Center);

            for (int i = -1; i < amount; i++)
                GetGeneratedChunk(_lastSpawnedChunk.ConnectPosition);
        }

        public Chunk GetGeneratedChunk(Vector3 position)
        {
            Chunk spawnedChunk =  _chunksPool.Get(position);
            spawnedChunk.SetWindows();
            _lastSpawnedChunk = spawnedChunk;
            return spawnedChunk;
        }

        public void SpawnChunk() => GetGeneratedChunk(_lastSpawnedChunk.ConnectPosition);
    }
}