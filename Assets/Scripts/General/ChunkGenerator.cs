using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    public class ChunkGenerator : MonoBehaviour
    {
        public event Action<IEnumerable<Window>> OnSpawnChunk;

        [SerializeField] private ChunkConfig _chunkDatabase;
        [Space(30)]
        [SerializeField][Range(1, 100)] private int _startableChunksCount;

        private WayMatrix _wayMatrix = new();
        private Pool<Road> _roadPool;
        private Pool<District> _districtPool;
        private Road _lastRoad;
        private List<Window> _windows = new();

        public void EnableChunks(Container chunksContainer) 
        {
            _roadPool = new(new RoadFactory(_chunkDatabase, SpawnChunk), chunksContainer, _startableChunksCount);
            _districtPool = new(new DistrictFactory(_chunkDatabase), chunksContainer, _chunkDatabase.DistrictsPrefabsCount);
            SpawnStartableChunk(chunksContainer);
            SpawnStartableChunks(_startableChunksCount);
        }

        private void SpawnStartableChunk(Container chunkContainer)
        {
            float offset = 3.5f;
            _lastRoad = Instantiate(_chunkDatabase.StartableChunk,
            _wayMatrix.GetPosition(MatrixPosition.Down) + Vector3.down * offset,
            Quaternion.identity, chunkContainer.transform);
            _lastRoad.gameObject.AddComponent<Mover>().Receive(_chunkDatabase);
            _lastRoad.gameObject.AddComponent<Disappearer>().SetDisappearPoint(Vector3.back * 50);
        }

        private void SpawnStartableChunks(int chunksCount)
        {
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