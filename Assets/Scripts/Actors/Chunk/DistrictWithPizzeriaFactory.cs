using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Assets.Scripts
{
    public class DistrictWithPizzeriaFactory : ActorFactory<PizzeriaDistrict>
    {
        private WayMatrix _wayMatrix = new();
        private ChunkConfig _config;

        public DistrictWithPizzeriaFactory(ChunkConfig chunkDatabase) => _config = chunkDatabase;

        public override PizzeriaDistrict GetCreated()
        {
            PizzeriaDistrict district = Object.Instantiate(_config.DistrictWithPizzeriaPrefab);
            district.gameObject.AddComponent<Mover>().Receive(_config);

            district.gameObject
                .AddComponent<Disappearer>()
                .SetDisappearPoint(_wayMatrix.DisappearPoint);

            return district;
        }
    }

}
