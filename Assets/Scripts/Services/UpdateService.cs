using System;
using UnityEngine;

namespace Services
{
    public sealed class UpdateService : MonoBehaviour
    {
        public static Action OnLateUpdate;
        public static Action OnUpdate;
        public static Action OnFixedUpdate;

        private void LateUpdate() => OnLateUpdate?.Invoke();

        private void Update() => OnUpdate?.Invoke();

        private void FixedUpdate() => OnFixedUpdate?.Invoke();
    }
}