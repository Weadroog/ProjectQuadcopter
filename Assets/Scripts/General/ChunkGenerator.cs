using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    public class ChunkGenerator : MonoBehaviour
    {
        public event Action<IEnumerable<Window>> OnSpawnChunk;

        [SerializeField] private ChunkDatabase _chunkDatabase;
        [Space(30)]
        [SerializeField][Range(1, 100)] private float _startableChunksCount;

        private WayMatrix _wayMatrix = new();
        private Pool<Road> _roadPool;
        private Pool<District> _districtPool;
        private Road _lastRoad;
        private List<Window> _windows = new();

        public void EnableChunks(Container chunksContainer, int startableChunkCount) 
        {
            _roadPool = new(new RoadFactory(_chunkDatabase, SpawnChunk), chunksContainer, startableChunkCount);
            _districtPool = new(new DistrictFactory(_chunkDatabase), chunksContainer, _chunkDatabase.DistrictsPrefabsCount);
            SpawnStartableChunks(startableChunkCount);
        }

        private void SpawnStartableChunks(int chunksCount)
        {
            _lastRoad = _roadPool.Get(_wayMatrix.GetPosition(MatrixPosition.Down) + Vector3.down * WayMatrix.Spacing);

            for (int i = 0; i < chunksCount; i++)
                SpawnChunk();
        }

        private void SpawnChunk()
        {
            _windows.Clear();
            _lastRoad = _roadPool.Get(_lastRoad.CentralConnectPosition);
            District leftDistrict = _districtPool.Get(_lastRoad.LeftConnectPosition);
            District rightDistrict = _districtPool.Get(_lastRoad.RightConnectPosition);
            leftDistrict.transform.position += Vector3.left * leftDistrict.Size.x / 2;
            rightDistrict.transform.position += Vector3.right * rightDistrict.Size.x / 2;
            rightDistrict.transform.localEulerAngles = new Vector3(0, 180, 0);
            leftDistrict.transform.localEulerAngles = new Vector3(0, 0, 0);
            _windows.AddRange(leftDistrict.GetWindows());
            _windows.AddRange(rightDistrict.GetWindows());
            OnSpawnChunk?.Invoke(_windows);
        }
    }
}