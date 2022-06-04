using UnityEngine;

namespace Assets.Scripts
{
    public class DistrictFactory : ActorFactory<District>
    {
        private WayMatrix _wayMatrix = new();
        private ChunkDatabase _chunkDatabase;

        public DistrictFactory(ChunkDatabase chunkDatabase) => _chunkDatabase = chunkDatabase;

        public override District GetCreated()
        {
            District district = Object.Instantiate(_chunkDatabase.DistrictPrefab);
            district.gameObject.AddComponent<Mover>();

            district.gameObject
                .AddComponent<Disappearer>()
                .SetDisappearPoint(_wayMatrix.DisappearPoint);

            return district;
        }
    }
}
