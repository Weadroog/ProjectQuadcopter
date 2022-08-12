using UnityEngine;
using General;
using NaughtyAttributes;

namespace Entities
{
    [CreateAssetMenu(menuName = "Config/Client", fileName = "New Client Config")]
    public class ClientConfig : Config, ICanMove, ICanDetect
    {
        [SerializeField] private Client[] _prefabs;
        [SerializeField, MinMaxSlider(-100, 100), BoxGroup("Detection")] private Vector2 _xDetectionRange;
        [SerializeField, MinMaxSlider(-100, 100), BoxGroup("Detection")] private Vector2 _zDetectionRange;
        [SerializeField, MinMaxSlider(-100, 100), BoxGroup("Detection")] private Vector2 _yDetectionRange;

        public Client Prefab => _prefabGetter.Get(_prefabs);
        public float SelfSpeed => 0;
        public float XDetectionDistanceLeft => _xDetectionRange.x;
        public float XDetectionDistanceRight => _xDetectionRange.y;
        public float ZDetectionDistanceForward => _zDetectionRange.y;
        public float ZDetectionDistanceBackward => _zDetectionRange.x;
        public float YDetectionDistanceUp => _yDetectionRange.y;
        public float YDetectionDistanceDown => _yDetectionRange.x;
    }
}
