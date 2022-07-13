using UnityEngine;
using NaughtyAttributes;
using General;

namespace Entities
{
    [CreateAssetMenu(menuName = "Config/Bird", fileName = "New Bird Config")]
    public class BirdConfig : Config, ICanMove, ICanDetect
    {
        [SerializeField] private Bird[] _prefabs;
        [SerializeField][Range(1, 100)] private float _selfSpeed;
        [SerializeField, MinMaxSlider(-100, 100), BoxGroup("Detection")] private Vector2 _xDetectionRange;
        [SerializeField, MinMaxSlider(-100, 100), BoxGroup("Detection")] private Vector2 _zDetectionRange;
        [SerializeField, MinMaxSlider(-100, 100), BoxGroup("Detection")] private Vector2 _yDetectionRange;

        public Bird Prefab => _prefabGetter.Get(_prefabs);
        public float SelfSpeed => _selfSpeed;
        public float XDetectionDistanceLeft => Mathf.Abs(_xDetectionRange.x);
        public float XDetectionDistanceRight => Mathf.Abs(_xDetectionRange.y);
        public float ZDetectionDistanceForward => Mathf.Abs(_zDetectionRange.x);
        public float ZDetectionDistanceBackward => Mathf.Abs(_zDetectionRange.y);
        public float YDetectionDistanceUp => Mathf.Abs(_yDetectionRange.x);
        public float YDetectionDistanceDown => Mathf.Abs(_yDetectionRange.y);
    }
}
