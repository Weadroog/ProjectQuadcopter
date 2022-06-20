using UnityEngine;

namespace Assets.Scripts
{
    public class QuadcopterNextReaction : Reaction
    {
        private Animator _animator;
        private SwipeController _swipeController;

        public QuadcopterNextReaction(Quadcopter quadcopter)
        {
            _animator = quadcopter.GetComponentInChildren<Animator>();
            _swipeController = quadcopter.GetComponent<SwipeController>();
        }

        public override void React()
        {
            _swipeController.SetStartablePosition(MatrixPosition.Center);
            _animator.Play(AnimationService.States.TakeNext);
        }
    }
}
