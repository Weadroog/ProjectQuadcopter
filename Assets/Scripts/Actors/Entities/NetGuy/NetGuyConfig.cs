using UnityEngine;

namespace Assets.Scripts
{
    [CreateAssetMenu(menuName = "Config/Net", fileName = "New Net Config")]
    public class NetGuyConfig : Config, ICanMove, ICanDetect
    {
        [SerializeField] private NetGuy[] _netGuyPrefabs;
        [SerializeField] private Net[] _netPrefabs;
        [SerializeField][Range(1, 100)] private float _detectionDistance;
        [SerializeField][Range(0, 10)] private float _leanOutingSpeed;

        public NetGuy NetGuyPrefab => _prefabGetter.Get(_netGuyPrefabs);
        public Net NetPrefab => _prefabGetter.Get(_netPrefabs);
        public float SelfSpeed => 0;
        public float DetectionDistance => _detectionDistance;
        public float LeanOutingSpeed => _leanOutingSpeed;
        public int NetPrefabsCount => _netPrefabs.Length;
    }
}
