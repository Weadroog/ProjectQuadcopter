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
            float xDistance = _config.DetectionWidth;
            float zDistance = _config.DetectionDistance;
            float distance = (Mathf
                .Pow(_target.transform.position.z - transform.position.z, 2) / Mathf
                .Pow(zDistance, 2) + Mathf
                .Pow(_target.transform.position.x - transform.position.x, 2) / Mathf
                .Pow(xDistance, 2));

            Draw(zDistance, xDistance, 60);

            if (distance <= ellipseRightSideValue)
                return true;

            return false;
        }

        private void Draw(float a, float b, int pointsNumber)
        {
            Vector3 previousPoint = new Vector3(b * Mathf.Sin(0) + transform.position.x, 0, a * Mathf.Cos(0) + transform.position.z);
            Vector3 nextPoint = previousPoint;

            for (float i = 2 * Mathf.PI / pointsNumber; i < 2 * Mathf.PI; i += 2 * Mathf.PI / pointsNumber)
            {
                nextPoint = new Vector3(b * Mathf.Sin(i) + transform.position.x, 0, a * Mathf.Cos(i) + transform.position.z);
                Debug.DrawLine(previousPoint, nextPoint, Color.red);
                previousPoint = nextPoint;
            }
        }

        private void OnDisable() => UpdateService.OnUpdate -= Detect;
    }
}