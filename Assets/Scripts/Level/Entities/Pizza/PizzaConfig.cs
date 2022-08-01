using UnityEngine;
using General;
using NaughtyAttributes;

namespace Entities
{
    [CreateAssetMenu(menuName = "Config/Pizza", fileName = "New Pizza Config")]
    public class PizzaConfig : Config, ICanDetect
    {
        [SerializeField] private Pizza _pizzaPrefab;
        [SerializeField, Range(0.1f, 3)] private float _flightTime;
        [SerializeField, Range(0, 100), BoxGroup("Detection")] private float _xDetectionRange;
        [SerializeField, MinMaxSlider(-100, 100), BoxGroup("Detection")] private Vector2 _zDetectionRange;
        [SerializeField, MinMaxSlider(-100, 100), BoxGroup("Detection")] private Vector2 _yDetectionRange;

        public Pizza PizzaPrefab => _pizzaPrefab;
        public float XDetectionDistanceLeft => _xDetectionRange;
        public float XDetectionDistanceRight => _xDetectionRange;
        public float ZDetectionDistanceForward => _zDetectionRange.x;
        public float ZDetectionDistanceBackward => _zDetectionRange.y;
        public float YDetectionDistanceUp => _yDetectionRange.y;
        public float YDetectionDistanceDown => _yDetectionRange.x;
        public float PizzaFlightTime => _flightTime;
    }

}

