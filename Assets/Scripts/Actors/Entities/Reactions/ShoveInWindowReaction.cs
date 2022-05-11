using UnityEngine;

namespace Assets.Scripts
{
    public class ShoveInWindowReaction : Reaction
    {
        private Animator _animator;

        public ShoveInWindowReaction(NetGuy netGuy) => _animator = netGuy.GetComponent<Animator>();

        public override void React() => _animator.SetFloat(AnimationService.Parameters.LeanOutingSide, 0);
    }
}
