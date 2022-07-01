using System;
using UnityEngine;

namespace Assets.Scripts
{
    public class EllipseDetector : Detector
    {
        public override event Action<Entity> OnDetect;
        public override event Action OnDetectAll;

        private bool _isDetection = true;
        private Entity _target;

        private void OnEnable()
        {
            UpdateService.OnUpdate += Detect;
            _target = FindObjectOfType<Quadcopter>();
        }

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
            float ellipseRightSideValue = 1;
            float xDistance = 12;
            float zDistance = _config.DetectionDistance;
            float distance = (Mathf
                .Pow(_target.transform.position.z - transform.position.z, 2) / Mathf
                .Pow(zDistance, 2) + Mathf
                .Pow(_target.transform.position.x - transform.position.x, 2) / Mathf
                .Pow(xDistance, 2));

            if (distance <= ellipseRightSideValue)
                return true;

            return false;
        }

        private void OnDisable() => UpdateService.OnUpdate -= Detect;
    }
}