using System;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Assets.Scripts
{
    public class ChunkFactory : ActorFactory<Chunk>
    {
        private WayMatrix _wayMatrix = new();
        private ChunkDatabase _database;
        private Action _spawnMethod;

        public ChunkFactory(ChunkDatabase database, Container container, Action spawnMethod) : base(container)
        {
            _database = database;
            _spawnMethod = spawnMethod;
        }

        public override Chunk GetCreated()
        {
            Chunk chunk = Object.Instantiate(_database.Prefab, _container.transform);
            chunk.gameObject.AddComponent<Mover>();

            chunk.gameObject
                .AddComponent<Disappearer>()
                .SetDisappearPoint(_wayMatrix.GetPosition(MatrixPosition.Center) + Vector3.back * chunk.Size)
                .OnDisappear += _spawnMethod;

            return chunk;
        }
    }
}
