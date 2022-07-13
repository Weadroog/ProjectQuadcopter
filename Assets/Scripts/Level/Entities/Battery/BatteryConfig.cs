using UnityEngine;
using NaughtyAttributes;
using General;

namespace Entities
{
    [CreateAssetMenu(menuName = "Config/Battery", fileName = "New Battery Config")]

    class BatteryConfig : Config, ICanMove, ICanDetect
    {
        [SerializeField] private Battery _prefab;
        [SerializeField, Range(0, 10)] private float _rotationSpeed;
        [SerializeField, MinMaxSlider(-100, 100), BoxGroup("Detection")] private Vector2 _xDetectionRange;
        [SerializeField, MinMaxSlider(-100, 100), BoxGroup("Detection")] private Vector2 _zDetectionRange;
        [SerializeField, MinMaxSlider(-100, 100), BoxGroup("Detection")] private Vector2 _yDetectionRange;

        public Battery Prefab => _prefab;
        public float SelfSpeed => 0;
        public float RotationSpeed => _rotationSpeed;

        public float XDetectionDistanceLeft => Mathf.Abs(_xDetectionRange.x);
        public float XDetectionDistanceRight => Mathf.Abs(_xDetectionRange.y);
        public float ZDetectionDistanceForward => Mathf.Abs(_zDetectionRange.x);
        public float ZDetectionDistanceBackward => Mathf.Abs(_zDetectionRange.y);
        public float YDetectionDistanceUp => Mathf.Abs(_yDetectionRange.x);
        public float YDetectionDistanceDown => Mathf.Abs(_yDetectionRange.y);
    }
}
