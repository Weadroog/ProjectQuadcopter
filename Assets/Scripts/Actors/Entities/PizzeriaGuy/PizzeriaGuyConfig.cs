using UnityEngine;
using NaughtyAttributes;

namespace Assets.Scripts
{
    [CreateAssetMenu(menuName = "Config/PizzeriaGuy", fileName = "New Pizzeria Guy Config")]
    public class PizzeriaGuyConfig : Config, ICanDetect, ICanMove
    {
        [SerializeField] private PizzeriaGuy[] _prefabs;
        [SerializeField] private Pizza[] _pizzaPrefabs;
        [SerializeField] [Range(1,30)] private int _bypassOffset;
        [SerializeField] [Range(1, 15)] private float _detectZoneLength;
        [SerializeField] [MinMaxSlider(-2, 2)] private Vector2Int _detectFloors;


        public PizzeriaGuy Prefab => _prefabGetter.Get(_prefabs);
        public Pizza PizzaPrefab => _prefabGetter.Get(_pizzaPrefabs);
        public float DetectionDistance => _bypassOffset;
        public float DetectionWidth => 0;
        public int DetectFloorsUp => _detectFloors.y;
        public int DetectFloorsDown => _detectFloors.x;
        public float DetectZoneLength => _detectZoneLength;
        public float SelfSpeed => 0;

    }
}


