using UnityEngine;
using Services;

namespace Entities
{
    public class Client : Entity 
    {
        private Animator _animator;

        private void Awake()
        {
            _animator = GetComponentInChildren<Animator>(); 
            _animator.keepAnimatorControllerStateOnDisable = true;
        }

        private void OnEnable() => _animator.SetFloat(AnimationService.Parameters.Side, Mathf.Clamp(transform.position.x, -1, 1));
    }
}

