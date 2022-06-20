using UnityEngine;

namespace Assets.Scripts
{
    [CreateAssetMenu(menuName = "Config/Battery", fileName = "New Battery Config")]

    class BatteryConfig : ActorConfig<Battery>, ICanMove, ICanDetect
    {
        [SerializeField] [Range(0, 10)] private float _rotationSpeed;
        [SerializeField] [Range(0, 10)] private float _detectionDistance;

        public float SelfSpeed => 0;
        public float DetectionDistance => _detectionDistance;
        public float RotationSpeed => _rotationSpeed;
    }
}
