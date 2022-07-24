using System;
using UnityEngine;

namespace Services
{
    public class GlobalSpeedService : MonoBehaviour
    {
        public static event Action OnStartup;
        public static event Action OnStop;

        [SerializeField][Range(0, 100)]private float _speed;

        public static GlobalSpeedService Instance { get; private set; }
        public static float Speed { get; private set; }
        public static float Acceleration => 0.1f;

        private void Awake() => Instance = this;

        private void OnEnable()
        {
            UpdateService.OnUpdate += SpeedUp;
            Speed = _speed;
            OnStartup?.Invoke();
        }

        private static void SpeedUp() => Speed += Acceleration * Time.deltaTime;

        private void OnDisable()
        {
            UpdateService.OnUpdate -= SpeedUp;
            Speed = 0;
            OnStop?.Invoke();
        }
    }
}