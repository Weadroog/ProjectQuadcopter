using UnityEngine;

namespace Assets.Scripts
{
    public class DistrictFactory : ActorFactory<District>
    {
        private WayMatrix _wayMatrix = new();
        private ChunkConfig _config;

        public DistrictFactory(ChunkConfig chunkDatabase) => _config = chunkDatabase;

        public override District GetCreated()
        {
            District district = Object.Instantiate(_config.DistrictPrefab);
            district.gameObject.AddComponent<Mover>().Receive(_config);

            district.gameObject
                .AddComponent<Disappearer>()
                .SetDisappearPoint(_wayMatrix.DisappearPoint);

            return district;
        }
    }
}
