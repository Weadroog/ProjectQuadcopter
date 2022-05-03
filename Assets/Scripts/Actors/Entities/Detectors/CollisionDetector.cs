using System;
using UnityEngine;

namespace Assets.Scripts
{
    public class CollisionDetector : MonoBehaviour, IDetector
    {
        public event Action OnDetect;

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out Quadcopter quadcopter))
                OnDetect?.Invoke();
        }
    }
}