using UnityEngine;

namespace Assets.Scripts
{
    public class SpeedService : MonoBehaviour
    {
        private static float _speed;

        public static float Speed { get; private set; }
        public static float Acceleration => 0.001f;

        private void OnEnable()
        {
            UpdateService.OnUpdate += SpeedUp;
            Speed = _speed;
        }

        public void SetStartableSpeed(float startableSpeed) => _speed = Speed = startableSpeed;

        private static void SpeedUp() => Speed += Acceleration * Time.deltaTime;

        private void OnDisable()
        {
            UpdateService.OnUpdate -= SpeedUp;
            Speed = 0;
        }
    }
}