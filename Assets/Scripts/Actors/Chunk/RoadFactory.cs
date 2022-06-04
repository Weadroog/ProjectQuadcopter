using System;

namespace Assets.Scripts
{
    public class RoadFactory : ActorFactory<Road>
    {
        private WayMatrix _wayMatrix = new();
        private ChunkDatabase _chunkDatabase;
        private Action _chunkSpawn;

        public RoadFactory(ChunkDatabase chunkDatabase, Action chunkSpawn)
        {
            _chunkDatabase = chunkDatabase;
            _chunkSpawn = chunkSpawn;
        }

        public override Road GetCreated()
        {
            Road road = UnityEngine.Object.Instantiate(_chunkDatabase.RoadPrefab);
            road.gameObject.AddComponent<Mover>();

            road.gameObject
                .AddComponent<Disappearer>()
                .SetDisappearPoint(_wayMatrix.DisappearPoint)
                .OnDisappear += _chunkSpawn;

            return road;
        }
    }
}
