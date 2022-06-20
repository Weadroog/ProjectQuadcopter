using UnityEngine;

namespace Assets.Scripts
{
    [CreateAssetMenu(menuName = "Config/Car", fileName = "New Car Config")]
    public class CarConfig : MultiplePrefabActorConfig<Car>, ICanMove, ICanDetect
    {
        [SerializeField] [Range(1, 100)] private float _selfSpeed;
        [SerializeField] [Range(1, 100)] private float _detectionDistance;

        public float SelfSpeed => _selfSpeed;
        public float DetectionDistance => _detectionDistance;
    }
}
