using UnityEngine;

namespace Assets.Scripts
{
    [CreateAssetMenu(menuName = "Config/Battery", fileName = "New Battery Config")]

    class BatteryConfig : Config, ICanMove, ICanDetect
    {
        [SerializeField] private Battery _prefab;
        [SerializeField] [Range(0, 10)] private float _rotationSpeed;
        [SerializeField] [Range(0, 10)] private float _detectionDistance;

        public Battery Prefab => _prefab;
        public float SelfSpeed => 0;
        public float DetectionDistance => _detectionDistance;
        public float DetectionWidth => 0;
        public float RotationSpeed => _rotationSpeed;

    }
}
