using System;
using General;
using Level;
using Components;

namespace Chunk
{
    public class RoadFactory : ActorFactory<Road>
    {
        private WayMatrix _wayMatrix = new();
        private ChunkConfig _config;
        private Action _chunkSpawn;

        public RoadFactory(ChunkConfig chunkDatabase, Action chunkSpawn)
        {
            _config = chunkDatabase;
            _chunkSpawn = chunkSpawn;
        }

        public override Road GetCreated()
        {
            Road road = UnityEngine.Object.Instantiate(_config.RoadPrefab);
            road.gameObject.AddComponent<Mover>().Receive(_config);

            road.gameObject.AddComponent<Disappearer>().OnDisappear += _chunkSpawn;

            return road;
        }
    }
}
