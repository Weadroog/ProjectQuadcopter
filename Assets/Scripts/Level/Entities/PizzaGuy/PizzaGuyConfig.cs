using UnityEngine;
using NaughtyAttributes;
using General;

namespace Entities
{
    [CreateAssetMenu(menuName = "Config/PizzaGuy", fileName = "New Pizza Guy Config")]
    public class PizzaGuyConfig : Config, ICanDetect, ICanMove
    {
        [SerializeField] private PizzaGuy[] _prefabs;
        [SerializeField] private Pizza[] _pizzaPrefabs;
        [SerializeField, Range(0, 100), BoxGroup("Detection")] private float _xDetectionRange;
        [SerializeField, MinMaxSlider(-100, 100), BoxGroup("Detection")] private Vector2 _zDetectionRange;
        [SerializeField, MinMaxSlider(-100, 100), BoxGroup("Detection")] private Vector2 _yDetectionRange;

        public PizzaGuy Prefab => _prefabGetter.Get(_prefabs);
        public Pizza PizzaPrefab => _prefabGetter.Get(_pizzaPrefabs);
        public float SelfSpeed => 0;
        public float XDetectionDistanceLeft => _xDetectionRange;
        public float XDetectionDistanceRight => _xDetectionRange;
        public float ZDetectionDistanceForward => _zDetectionRange.x;
        public float ZDetectionDistanceBackward => _zDetectionRange.y;
        public float YDetectionDistanceUp => _yDetectionRange.y;
        public float YDetectionDistanceDown => _yDetectionRange.x;
    }
}


