using UnityEngine;

namespace Assets.Scripts
{
    public sealed class Mover : ConfigReceiver<ICanMove>
    {
        private float _pushingSpeed;

        public float SelfSpeed => _config.SelfSpeed;

        private void OnEnable()
        {
            _pushingSpeed = 0;
            UpdateService.OnFixedUpdate += Move;
        }

        private void Move()
        {
            if (SpeedService.Speed > 0)
                transform.position += (SpeedService.Speed + SelfSpeed + _pushingSpeed) * Time.fixedDeltaTime * Vector3.back;
        }

        public void Push(float pusherSpeed) => _pushingSpeed = pusherSpeed - SelfSpeed;

        private void OnDisable() => UpdateService.OnFixedUpdate -= Move;
    }
}