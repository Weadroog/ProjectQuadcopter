using System;
using System.Collections;
using System.Collections.Generic;
using Assets.Scripts;
using UnityEngine;

public class VisibilityRangeDetector : MonoBehaviour, IDetector
{
    public event Action OnDetect;

    private float _range;
    private bool _isDetection = true;
    private void OnEnable() => UpdateService.OnUpdate += Detect;

    public void SetRange(float range) => _range = range;
    private void Detect()
    {
        if (IsTargetInRadius() && _isDetection)
        {
            OnDetect?.Invoke();
            _isDetection = false;
        }

        if (IsTargetInRadius() == false && _isDetection == false)
            _isDetection = true;
    }
    
    private bool IsTargetInRadius()
    {
        if (Physics.Raycast(transform.position, new Vector3(0, 0, -1), _range))  
            return true;

        return false;
    }

    private void OnDisable() => UpdateService.OnUpdate -= Detect;

    private void OnDrawGizmos()
    {
        if (_isDetection)
        {
            Gizmos.color = Color.blue;
        }
        else
        {
            Gizmos.color = Color.red;
        }

        Gizmos.DrawLine(transform.position, transform.position + new Vector3(0, 0,  -_range));
    }
}

