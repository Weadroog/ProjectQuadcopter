using System;
using UnityEngine;

namespace Assets.Scripts
{
    public class Disappearer : MonoBehaviour
    {
        public event Action OnDisappear;

        private Vector3 _disappearPoint;

        public Disappearer SetDisappearPoint(Vector3 disappearPoint)
        {
            _disappearPoint = disappearPoint;
            return this;
        }

        private void OnEnable() => UpdateService.OnUpdate += CheckEdgeOut;

        private void CheckEdgeOut()
        {
            if (transform.position.z <= _disappearPoint.z)
            {
                OnDisappear?.Invoke();
                gameObject.SetActive(false);
            }
        }

        private void OnDisable() => UpdateService.OnUpdate -= CheckEdgeOut;
    }
}