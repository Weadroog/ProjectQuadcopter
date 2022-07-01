using UnityEngine;

namespace Assets.Scripts
{
    [CreateAssetMenu(menuName = "Config/Net", fileName = "New Net Config")]
    public class NetGuyConfig : Config, ICanMove, ICanDetect
    {
        [SerializeField] private NetGuy[] _netGuyPrefabs;
        [SerializeField] private Net[] _netPrefabs;
        [SerializeField][Range(1, 100)] private float _detectionDistance;
        [SerializeField][Range(0, 10)] private float _shoveOutSpeed;
        [SerializeField][Range(0, 10)] private float _shoveInSpeed;

        private int _netGuyPrefabIndex;
        private int _netPrefabIndex;

        public NetGuy NetGuy
        {
            get
            {
                _netGuyPrefabIndex = (_netGuyPrefabIndex == _netGuyPrefabs.Length) ? 0 : _netGuyPrefabIndex;
                NetGuy prefab = _netGuyPrefabs[_netGuyPrefabIndex];
                _netGuyPrefabIndex++;
                return prefab;
            }
        }

        public Net Net
        {
            get
            {
                _netPrefabIndex = (_netPrefabIndex == _netPrefabs.Length) ? 0 : _netPrefabIndex;
                Net prefab = _netPrefabs[_netPrefabIndex];
                _netPrefabIndex++;
                return prefab;
            }
        }

        public float SelfSpeed => 0;
        public float DetectionDistance => _detectionDistance;
        public float ShoveOutSpeed => _shoveOutSpeed;
        public float ShoveInSpeed => _shoveInSpeed;
        public int NetPrefabsCount => _netPrefabs.Length;
    }
}
