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
            float yUpDistance = _config.DetectFloorsUp * WayMatrix.VerticalSpacing + WayMatrix.VerticalSpacing / 4;
            float yDownDistance = Mathf.Abs(_config.DetectFloorsDown) * WayMatrix.VerticalSpacing + WayMatrix.VerticalSpacing / 4;
            float xzDistance = (Mathf
                .Pow(_target.transform.position.z - transform.position.z, 2) / Mathf
                .Pow(zDistance, 2) + Mathf
                .Pow(_target.transform.position.x - transform.position.x, 2) / Mathf
                .Pow(xDistance, 2));
            float verticalDistanceToTarget = transform.position.y - _target.transform.position.y;
            bool isInVerticalDistance;

            Draw(yUpDistance, yDownDistance, zDistance, xDistance, 30);

            isInVerticalDistance = verticalDistanceToTarget > 0 
                ? yDownDistance >= Mathf.Abs(verticalDistanceToTarget) 
                : yUpDistance >= Mathf.Abs(verticalDistanceToTarget);

            if (xzDistance <= ellipseRightSideValue && isInVerticalDistance)
                return true;

            return false;
        }

        private void Draw(float yAxisUpLength, float yAxisDownLength, float zAxisLength, float xAxisLength, int pointsNumber)
        {
            Vector3 previousPoint = new Vector3(xAxisLength * Mathf.Sin(0) + transform.position.x, transform.position.y, zAxisLength * Mathf.Cos(0) + transform.position.z);
            Vector3 nextPoint;

            Debug.DrawLine(previousPoint + yAxisUpLength * Vector3.up, previousPoint + yAxisDownLength * Vector3.down, Color.green);

            for (float i = 2 * Mathf.PI / pointsNumber; i < 2 * Mathf.PI; i += 2 * Mathf.PI / pointsNumber)
            {
                nextPoint = new Vector3(xAxisLength * Mathf.Sin(i) + transform.position.x, transform.position.y, zAxisLength * Mathf.Cos(i) + transform.position.z);
                Debug.DrawLine(previousPoint, nextPoint, Color.red);
                Debug.DrawLine(nextPoint + yAxisUpLength * Vector3.up, nextPoint + yAxisDownLength * Vector3.down, Color.green);
                previousPoint = nextPoint;
            }
        }

        private void OnDisable() => UpdateService.OnUpdate -= Detect;
    }
}