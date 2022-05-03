using UnityEngine;

namespace Assets.Scripts
{
    public sealed class Mover : MonoBehaviour
    {
        private float _selfSpeed;

        private void OnEnable() => UpdateService.OnFixedUpdate += Move;

        public void SetSelfSpeed(float selfSpeed) => _selfSpeed = selfSpeed;

        private void Move() => transform.position += (SpeedService.Speed + _selfSpeed) * Time.fixedDeltaTime * Vector3.back;

        private void OnDisable() => UpdateService.OnFixedUpdate -= Move;
    }
}