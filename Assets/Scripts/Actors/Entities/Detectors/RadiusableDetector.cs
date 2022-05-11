using System;
using UnityEngine;

namespace Assets.Scripts
{
    public class RadiusableDetector : MonoBehaviour, IDetector
    {
        public event Action<Entity> OnDetect;
        public event Action OnDetectAll;

        private float _radius;
        private bool _isDetection = true;
        private Entity _target;

        private void OnEnable()
        {
            UpdateService.OnUpdate += Detect;
            _target = FindObjectOfType<Quadcopter>();
        }

        public void SetRadius(float radius) => _radius = radius;

        private void Detect()
        {
            if (IsTargetInRadius() && _isDetection)
            {
                OnDetectAll?.Invoke();
                OnDetect?.Invoke(_target);
                _isDetection = false;
            }

            if (IsTargetInRadius() == false && _isDetection == false)
                _isDetection = true;
        }

        private bool IsTargetInRadius()
        {
            float semiMajorAxis = 2.2f;
            float semiMinorAxis = 0.8f;
            float distance = (Mathf.Pow(_target.transform.position.z - transform.position.z, 2) / Mathf.Pow(semiMajorAxis, 2) + Mathf.Pow(_target.transform.position.x - transform.position.x, 2) / Mathf.Pow(semiMinorAxis, 2));

            if (distance <= _radius)
                return true;

            return false;
        }

        private void OnDisable() => UpdateService.OnUpdate -= Detect;
    }
}