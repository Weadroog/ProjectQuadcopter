using UnityEngine;

namespace Assets.Scripts
{
    [CreateAssetMenu(menuName = "Config/Car", fileName = "New Car Config")]
    public class CarConfig : Config, ICanMove, ICanDetect
    {
        [SerializeField] private Car[] _prefabs;
        [SerializeField] [Range(1, 100)] private float _selfSpeed;
        [SerializeField] [Range(1, 100)] private float _detectionDistance;

        public Car Prefab => _prefabGetter.Get(_prefabs);
        public float SelfSpeed => _selfSpeed;
        public float DetectionDistance => _detectionDistance;
        public float DetectionWidth => 0;
    }
}
