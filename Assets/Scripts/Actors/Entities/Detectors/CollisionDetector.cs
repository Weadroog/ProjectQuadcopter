using System;
using UnityEngine;

namespace Assets.Scripts
{
    public class CollisionDetector : Detector
    {
        public override event Action<Entity> OnDetect;
        public override event Action OnDetectAll;

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