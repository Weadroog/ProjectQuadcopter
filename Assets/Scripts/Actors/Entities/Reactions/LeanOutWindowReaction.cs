using UnityEngine;

namespace Assets.Scripts
{
    public class LeanOutWindowReaction : Reaction
    {
        private NetGuy _netGuy;
        private Animator _animator;

        public LeanOutWindowReaction(NetGuy netGuy)
        {
            _netGuy = netGuy;
            _animator = netGuy.GetComponent<Animator>();
        }

        public override void React() => _animator.SetFloat(AnimationService.Parameters.LeanOutingSide, -Mathf.Clamp(_netGuy.transform.position.x, -1, 1));
    }
}
