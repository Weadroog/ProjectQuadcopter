using UnityEngine;

namespace Assets.Scripts
{
    public class ShoveingInWindowReaction : Reaction
    {
        private Animator _animator;

        public ShoveingInWindowReaction(NetGuy netGuy) => _animator = netGuy.GetComponent<Animator>();

        public override void React() => _animator.SetFloat(AnimationService.Parameters.LeanOutingSide, 0);
    }
}
