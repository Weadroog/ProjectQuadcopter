using System;
using UnityEngine;
using Services;
using Entities;

namespace Components
{
    public class FrontDetector : Detector
    {
        public override event Action<Entity> OnDetect;
        public override event Action OnDetectAll;

        private bool _isDetection = true;

        private void OnEnable() => UpdateService.OnUpdate += Detect;

        private void Detect()
        {
            if (IsTargetInRadius(out Entity target) && _isDetection)
            {
                OnDetectAll?.Invoke();
                OnDetect?.Invoke(target);
                _isDetection = false;
            }

            if (IsTargetInRadius(out target) == false && _isDetection == false)
                _isDetection = true;
        }

        private bool IsTargetInRadius(out Entity target)
        {
            Ray ray = new Ray(transform.position, Vector3.back);
            Debug.DrawRay(ray.origin, ray.direction * _config.XDetectionDistanceLeft, Color.red);

            if (Physics.Raycast(ray.origin, ray.direction, out RaycastHit detectionInfo, _config.XDetectionDistanceLeft))
            {
                if (detectionInfo.collider.TryGetComponent(out target))
                {
                    return true;
                }
            }

            target = null;
            return false;
        }

        private void OnDisable() => UpdateService.OnUpdate -= Detect;
    }
}