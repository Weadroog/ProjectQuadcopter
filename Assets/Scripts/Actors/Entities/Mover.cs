using UnityEngine;

namespace Assets.Scripts
{
    public sealed class Mover : ConfigReceiver<ICanMove>
    {
        private float _currentSpeed;

        public float CurrentSpeed => _currentSpeed;

        private void OnEnable()
        {
            UpdateService.OnFixedUpdate += Move;

            if (_config != null)
                SetCurrentSpeed(_config.SelfSpeed);
        }

        public void SetCurrentSpeed(float speed) => _currentSpeed = speed;

        private void Move() => transform.position += (SpeedService.Speed + _currentSpeed) * Time.fixedDeltaTime * Vector3.back;

        private void OnDisable() => UpdateService.OnFixedUpdate -= Move;
    }
}