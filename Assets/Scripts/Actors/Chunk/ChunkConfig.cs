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

        private int _districtPrefabIndex;
        private int _districtWithPizzeriaPrefabIndex;

        public District DistrictPrefab
        {
            get
            {
                _districtPrefabIndex = (_districtPrefabIndex == _districtsPrefab.Length) ? 0 : _districtPrefabIndex;
                District prefab = _districtsPrefab[_districtPrefabIndex];
                _districtPrefabIndex++;
                return prefab;
            }
        }

        public PizzeriaDistrict DistrictWithPizzeriaPrefab
        {
            get
            {
                _districtWithPizzeriaPrefabIndex = (_districtWithPizzeriaPrefabIndex == _districtsWithPizzeriaPrefab.Length) ? 0 : _districtWithPizzeriaPrefabIndex;
                PizzeriaDistrict prefab = _districtsWithPizzeriaPrefab[_districtWithPizzeriaPrefabIndex];
                _districtWithPizzeriaPrefabIndex++;
                return prefab;
            }
        }

        public Road RoadPrefab => _roadPrefab;
        public Road StartableChunk => _startableChunk;
        public int DistrictsPrefabsCount => _districtsPrefab.Length;
        public int DistrictsWithPizzeeriaPrefabsCount => _districtsWithPizzeriaPrefab.Length;
        public float SelfSpeed => 0;
    }
}
