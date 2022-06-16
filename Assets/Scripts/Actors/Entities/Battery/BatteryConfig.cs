using UnityEngine;

namespace Assets.Scripts
{
    [CreateAssetMenu(menuName = "Config/Battery", fileName = "New Battery Config")]

    class BatteryConfig : ActorConfig<Battery>
    {
        [SerializeField] [Range(0, 10)] private float _rotationSpeed;


        public float RotationSpeed => _rotationSpeed;
    }
}
