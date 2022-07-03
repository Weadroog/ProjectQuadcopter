using UnityEngine;

namespace Assets.Scripts
{
    [CreateAssetMenu(menuName = "Config/Chunk Config", fileName = "New Chunk Config")]
    public class ChunkConfig : Config, ICanMove
    {
        [SerializeField] protected District[] _districtsPrefab;
        [SerializeField] protected PizzeriaDistrict[] _districtsWithPizzeriaPrefab;
        [SerializeField] private Road _roadPrefab;
        [SerializeField] private Road _startableChunk;

        public District DistrictPrefab => _prefabGetter.Get(_districtsPrefab);
        public PizzeriaDistrict DistrictWithPizzeriaPrefab => _prefabGetter.Get(_districtsWithPizzeriaPrefab);
        public Road RoadPrefab => _roadPrefab;
        public Road StartableChunk => _startableChunk;
        public int DistrictsPrefabsCount => _districtsPrefab.Length;
        public int DistrictsWithPizzeeriaPrefabsCount => _districtsWithPizzeriaPrefab.Length;
        public float SelfSpeed => 0;
    }
}
