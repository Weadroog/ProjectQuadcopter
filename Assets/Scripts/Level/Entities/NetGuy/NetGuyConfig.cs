using UnityEngine;
using NaughtyAttributes;
using General;

namespace Entities
{
    [CreateAssetMenu(menuName = "Config/NetGuy", fileName = "New NetGuy Config")]
    public class NetGuyConfig : Config, ICanMove, ICanDetect
    {
        [SerializeField] private NetGuy[] _netGuyPrefabs;
        [SerializeField] private Net[] _netPrefabs;
        [SerializeField, Range(0, 10)] private float _shoveOutSpeed;
        [SerializeField, Range(0, 10)] private float _shoveInSpeed;
        [SerializeField, MinMaxSlider(-100, 100), BoxGroup("Detection")] private Vector2 _xDetectionRange;
        [SerializeField, MinMaxSlider(-100, 100), BoxGroup("Detection")] private Vector2 _yDetectionRange;
        [SerializeField, MinMaxSlider(-100, 100), BoxGroup("Detection")] private Vector2 _zDetectionRange;

        public NetGuy NetGuyPrefab => _prefabGetter.Get(_netGuyPrefabs);
        public Net NetPrefab => _prefabGetter.Get(_netPrefabs);
        public float SelfSpeed => 0;
        public float ShoveOutSpeed => _shoveOutSpeed;
        public float ShoveInSpeed => _shoveInSpeed;
        public float XDetectionDistanceLeft => _xDetectionRange.x;
        public float XDetectionDistanceRight => _xDetectionRange.y;
        public float ZDetectionDistanceForward => _zDetectionRange.y;
        public float ZDetectionDistanceBackward => _zDetectionRange.x;
        public float YDetectionDistanceUp => _yDetectionRange.y;
        public float YDetectionDistanceDown => _yDetectionRange.x;
    }
}
