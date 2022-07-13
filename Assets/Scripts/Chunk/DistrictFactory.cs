using UnityEngine;
using General;
using Level;
using Components;

namespace Chunk
{
    public class DistrictFactory : ActorFactory<District>
    {
        private ChunkConfig _config;

        public DistrictFactory(ChunkConfig chunkDatabase) => _config = chunkDatabase;

        public override District GetCreated()
        {
            District district = Object.Instantiate(_config.DistrictPrefab);
            district.gameObject.AddComponent<Mover>().Receive(_config);

            district.gameObject.AddComponent<Disappearer>();

            return district;
        }
    }
}
