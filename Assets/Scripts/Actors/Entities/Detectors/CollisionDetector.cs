using System;
using UnityEngine;

namespace Assets.Scripts
{
    public class CollisionDetector : MonoBehaviour, IDetector
    {
        public event Action<Entity> OnDetect;
        public event Action OnDetectAll;

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out Entity detectedEntity))
            {
                OnDetectAll?.Invoke();
                OnDetect?.Invoke(detectedEntity);
            }
        }
    }
}