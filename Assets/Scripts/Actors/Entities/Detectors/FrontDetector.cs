using System;
using UnityEngine;

namespace Assets.Scripts
{
    public class FrontDetector : MonoBehaviour, IDetector
    {
        public event Action<Entity> OnDetect;
        public event Action OnDetectAll;

        private float _detectionDistance;
        private bool _isDetection = true;

        private void OnEnable() => UpdateService.OnUpdate += Detect;

        public void SetDetectionDistance(float range) => _detectionDistance = range;

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
            Debug.DrawRay(ray.origin, ray.direction * _detectionDistance, Color.red);

            if (Physics.Raycast(ray.origin, ray.direction * _detectionDistance, out RaycastHit detectionInfo) && detectionInfo.collider.TryGetComponent(out target))
            {
                Debug.Log($"Впереди {target}");
                return true;
            }

            target = null;
            return false;
        }

        private void OnDisable() => UpdateService.OnUpdate -= Detect;
    }
}