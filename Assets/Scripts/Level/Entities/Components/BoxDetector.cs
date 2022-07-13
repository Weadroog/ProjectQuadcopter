using System;
using UnityEngine;
using Services;
using Entities;

namespace Components
{
    public class BoxDetector : Detector
    {
        public override event Action<Entity> OnDetect;
        public override event Action OnDetectAll;

        private bool _isDetection = true;
        private Entity _target;
        private float[] _xDetectionDistance = new float[2];
        private float[] _yDetectionDistance = new float[2];
        private float[] _zDetectionDistance = new float[2];

        private void OnEnable()
        {
            UpdateService.OnUpdate += Detect;
            _target = FindObjectOfType<Quadcopter>();

            if (_target)
            {
                _xDetectionDistance[0] = _config.XDetectionDistanceLeft;
                _xDetectionDistance[1] = _config.XDetectionDistanceRight;
                _yDetectionDistance[0] = _config.YDetectionDistanceDown;
                _yDetectionDistance[1] = _config.YDetectionDistanceUp;
                _zDetectionDistance[0] = _config.ZDetectionDistanceBackward;
                _zDetectionDistance[1] = _config.ZDetectionDistanceForward;
            }
        }

        private void Detect()
        {
            if (IsTargetInBox() && _isDetection)
            {
                OnDetectAll?.Invoke();
                OnDetect?.Invoke(_target);
                _isDetection = false;
            }

            if (IsTargetInBox() == false && _isDetection == false)
                _isDetection = true;
        }

        private bool IsTargetInBox()
        {
            Vector3 distance = _target.transform.position - transform.position;
            int xIndex = (int)Mathf.Clamp01(Mathf.Sign(distance.x) + 1);
            int yIndex = (int)Mathf.Clamp01(Mathf.Sign(distance.y) + 1);
            int zIndex = (int)Mathf.Clamp01(Mathf.Sign(distance.z) + 1);

            #if (UNITY_EDITOR)
            Draw();
            #endif

            return _xDetectionDistance[xIndex] >= Mathf.Abs(distance.x) && _yDetectionDistance[yIndex] >= Mathf.Abs(distance.y) && _zDetectionDistance[zIndex] >= Mathf.Abs(distance.z);
        }

        private void Draw()
        {
            Vector3 pos = transform.position;
            Vector3[] points = 
                { 
                pos + new Vector3(-_xDetectionDistance[0], -_yDetectionDistance[0], -_zDetectionDistance[0]),
                pos + new Vector3(_xDetectionDistance[1], -_yDetectionDistance[0], -_zDetectionDistance[0]),
                pos + new Vector3(_xDetectionDistance[1], -_yDetectionDistance[0], _zDetectionDistance[1]),
                pos + new Vector3(-_xDetectionDistance[0], -_yDetectionDistance[0], _zDetectionDistance[1]),
                pos + new Vector3(-_xDetectionDistance[0], -_yDetectionDistance[0], -_zDetectionDistance[0]),
                pos + new Vector3(-_xDetectionDistance[0], _yDetectionDistance[1], -_zDetectionDistance[0]),
                pos + new Vector3(_xDetectionDistance[1], _yDetectionDistance[1], -_zDetectionDistance[0]),
                pos + new Vector3(_xDetectionDistance[1], _yDetectionDistance[1], _zDetectionDistance[1]),
                pos + new Vector3(-_xDetectionDistance[0], _yDetectionDistance[1], _zDetectionDistance[1]),
                pos + new Vector3(-_xDetectionDistance[0], _yDetectionDistance[1], -_zDetectionDistance[0]),
                };

            for (int i = 0; i < points.Length - 1; i++)
            {
                Debug.DrawLine(points[i], points[i+1], Color.green);
            }

            for(int i = 1; i < 4; i++)
            {
                Debug.DrawLine(points[i], points[i+5], Color.green);
            }
        }

        private void OnDisable() => UpdateService.OnUpdate -= Detect;
    }
}