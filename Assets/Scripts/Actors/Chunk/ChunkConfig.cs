using UnityEngine;

namespace Assets.Scripts
{
    [CreateAssetMenu(menuName = "Config/Chunk Config", fileName = "New Chunk Config")]
    public class ChunkConfig : Config
    {
        [SerializeField] protected District[] _districtsPrefab;
        [SerializeField] private Road _roadPrefab;

        private int _districtPrefabIndex;

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
        public Road RoadPrefab => _roadPrefab;

        public int DistrictsPrefabsCount => _districtsPrefab.Length;
        

        
    }
}
