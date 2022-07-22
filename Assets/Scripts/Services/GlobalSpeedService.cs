using UnityEngine;

namespace Services
{
    public class GlobalSpeedService : MonoBehaviour
    {
        [SerializeField][Range(0, 100)]private float _speed;

        public static float Speed { get; private set; }
        public static float Acceleration => 0.1f;

        private void OnEnable()
        {
            UpdateService.OnUpdate += SpeedUp;
            Speed = _speed;
        }

        private static void SpeedUp() => Speed += Acceleration * Time.deltaTime;

        private void OnDisable()
        {
            UpdateService.OnUpdate -= SpeedUp;
            Speed = 0;
        }
    }
}