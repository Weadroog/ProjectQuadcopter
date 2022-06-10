using UnityEngine;

namespace Assets.Scripts
{
    public class SpeedService : MonoBehaviour
    {

        public static float Speed { get; private set; }
        public static float Acceleration { get => 0.001f; }

        public static void SetStartSpeed(float startSpeed) => Speed = startSpeed;

        private void OnEnable() => UpdateService.OnUpdate += SpeedUp;

        public static void SpeedUp() => Speed += Acceleration * Time.deltaTime;

        private void OnDisable() => UpdateService.OnUpdate -= SpeedUp;
    }
}