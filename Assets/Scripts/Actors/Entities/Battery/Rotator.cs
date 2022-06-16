using UnityEngine;

namespace Assets.Scripts
{
    class Rotator : MonoBehaviour
    {
        private float _rotationSpeed;
        private readonly float _speedFactorMax = 100;
        private Vector3 _speedFactor;


        private void OnEnable()
        {
            SetSpeedFactor();
            UpdateService.OnUpdate += Rotate;
        }

        public void SetRotationSpeed(float rotationSpeed) => _rotationSpeed = rotationSpeed;

        private void SetSpeedFactor() => _speedFactor = new Vector3(Random.Range(0, _speedFactorMax), Random.Range(0, _speedFactorMax), Random.Range(0, _speedFactorMax));

        private void Rotate() => gameObject.transform.Rotate(Time.deltaTime * _rotationSpeed * _speedFactor);

        private void OnDisable() => UpdateService.OnUpdate -= Rotate;
    }
}
