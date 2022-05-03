using UnityEngine;

namespace Assets.Scripts
{
    public class ChunkFactory : ActorFactory<Chunk, ChunkConfig>
    {
        private WayMatrix _wayMatrix = new WayMatrix();
        private SpawnMethod _spawnMethod;

        public ChunkFactory(ChunkConfig config, Container container, SpawnMethod spawnMethod) : base(config, container) => _spawnMethod = spawnMethod;

        public override Chunk GetCreated()
        {
            Chunk chunk = Object.Instantiate(_config.Prefab, _container.transform);
            Disappearer disappearer = chunk.gameObject.AddComponent<Disappearer>();
            chunk.gameObject.AddComponent<Mover>();
            disappearer.OnDisappear += _spawnMethod;
            disappearer.SetDisappearPoint(_wayMatrix.GetPosition(MatrixPosition.Center) + Vector3.back * chunk.Size);
            return chunk;
        }
    }
}
