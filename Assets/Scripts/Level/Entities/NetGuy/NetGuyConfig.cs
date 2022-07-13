using UnityEngine;
using NaughtyAttributes;
using General;

namespace Entities
{
    [CreateAssetMenu(menuName = "Config/Net", fileName = "New Net Config")]
    public class NetGuyConfig : Config, ICanMove, ICanDetect
    {
        [SerializeField] private NetGuy[] _netGuyPrefabs;
        [SerializeField] private Net[] _netPrefabs;
        [SerializeField] [Range(0, 10)] private float _shoveOutSpeed;
        [SerializeField] [Range(0, 10)] private float _shoveInSpeed;
        [SerializeField, Range(0, 100), BoxGroup("Detection")] private float _xDetectionRange;
        [SerializeField, Range(0, 100), BoxGroup("Detection")] private float _zDetectionDistanceForward;
        [SerializeField, Range(0, 100), BoxGroup("Detection")] private float _zDetectionDistanceBackward;
        [SerializeField, Range(0, 100), BoxGroup("Detection")] private float _yDetectionDistanceUp;
        [SerializeField, Range(0, 100), BoxGroup("Detection")] private float _yDetectionDistanceDown;

        public NetGuy NetGuyPrefab => _prefabGetter.Get(_netGuyPrefabs);
        public Net NetPrefab => _prefabGetter.Get(_netPrefabs);
        public float SelfSpeed => 0;
        public float ShoveOutSpeed => _shoveOutSpeed;
        public float ShoveInSpeed => _shoveInSpeed;
        public int NetPrefabsCount => _netPrefabs.Length;
        public float XDetectionDistanceLeft => _xDetectionRange;
        public float XDetectionDistanceRight => _xDetectionRange;
        public float ZDetectionDistanceForward => _zDetectionDistanceForward;
        public float ZDetectionDistanceBackward => _zDetectionDistanceBackward;
        public float YDetectionDistanceUp => _yDetectionDistanceUp;
        public float YDetectionDistanceDown => _yDetectionDistanceDown;
    }
}
