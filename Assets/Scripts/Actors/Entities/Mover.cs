using UnityEngine;

namespace Assets.Scripts
{
    public sealed class Mover : ConfigReceiver<ICanMove>
    {
        private float _pushSpeed;

        public float SelfSpeed => _config.SelfSpeed;

        public void Push(float pusherSpeed)
        {
            _pushSpeed = pusherSpeed - SelfSpeed;
        }

        private void OnEnable()
        {
            _pushSpeed = 0;
            UpdateService.OnFixedUpdate += Move;
        }

        private void Move() => transform.position += (SpeedService.Speed + SelfSpeed + _pushSpeed) * Time.fixedDeltaTime * Vector3.back;

        private void OnDisable() => UpdateService.OnFixedUpdate -= Move;
    }
}