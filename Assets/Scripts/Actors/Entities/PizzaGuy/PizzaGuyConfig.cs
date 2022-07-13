using UnityEngine;
using NaughtyAttributes;

namespace Assets.Scripts
{
    [CreateAssetMenu(menuName = "Config/PizzeriaGuy", fileName = "New Pizzeria Guy Config")]
    public class PizzaGuyConfig : Config, ICanDetect, ICanMove
    {
        [SerializeField] private PizzaGuy[] _prefabs;
        [SerializeField] private Pizza[] _pizzaPrefabs;
        [SerializeField, Range(0, 100), BoxGroup("Detection")] private float _xDetectionRadius;
        [SerializeField, MinMaxSlider(-100, 100), BoxGroup("Detection")] private Vector2 _zDetectionRange;
        [SerializeField, MinMaxSlider(-100, 100), BoxGroup("Detection")] private Vector2 _yDetectionRange;


        public PizzaGuy Prefab => _prefabGetter.Get(_prefabs);
        public Pizza PizzaPrefab => _prefabGetter.Get(_pizzaPrefabs);
        public float SelfSpeed => 0;
        public float XDetectionDistanceLeft => _xDetectionRadius / 2;
        public float XDetectionDistanceRight => _xDetectionRadius / 2;
        public float ZDetectionDistanceForward => _zDetectionRange.x;
        public float ZDetectionDistanceBackward => _zDetectionRange.y;
        public float YDetectionDistanceUp => _yDetectionRange.x;
        public float YDetectionDistanceDown => _yDetectionRange.y;
    }
}


