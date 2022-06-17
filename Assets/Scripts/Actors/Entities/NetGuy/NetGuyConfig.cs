using UnityEngine;

namespace Assets.Scripts
{
    [CreateAssetMenu(menuName = "Config/Net", fileName = "New Net Config")]
    public class NetGuyConfig : MultiplePrefabActorConfig<NetGuy>, ICanMove, ICanDetect
    {
        [SerializeField] private Net[] _netPrefabs;
        [SerializeField][Range(1, 100)] private float _detectionDistance;
        [SerializeField][Range(0, 10)] private float _leanOutingSpeed;

        private int _netPrefabIndex;

        public Net Net
        {
            get
            {
                _netPrefabIndex = (_netPrefabIndex == _prefabs.Length) ? 0 : _netPrefabIndex;
                Net prefab = _netPrefabs[_netPrefabIndex];
                _netPrefabIndex++;
                return prefab;
            }
        }

        public float SelfSpeed => 0;
        public float DetectionDistance => _detectionDistance;
        public float LeanOutingSpeed => _leanOutingSpeed;

    }
}
