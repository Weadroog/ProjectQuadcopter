using UnityEngine;

namespace Assets.Scripts
{
    public class WindowLeanOuter : MonoBehaviour
    {
        private Animator _animator;

        private void Awake() => _animator = GetComponent<Animator>();

        public void LeanOutWindow()
        {
            _animator.SetFloat(AnimationService.Parameters.LeanOutingSide, - Mathf.Clamp(transform.position.x, -1, 1));
        }

        private void OnDisable() => _animator.SetFloat(AnimationService.Parameters.LeanOutingSide, 0);
    }
}