using UnityEngine;

namespace Assets.Scripts
{
    [CreateAssetMenu(menuName = "Config/Car", fileName = "New Car Config")]
    public class CarConfig : MultiplePrefabActorConfig<Car>
    {
        [SerializeField] [Range(1, 10)] private float _moveSpeed;
        [SerializeField] [Range(1, 10)] private float _visibilDetector;

        public float MoveSpeed { get => _moveSpeed; }
        public float VisibilDetector { get => _visibilDetector; }
    }
}
