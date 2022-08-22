using UnityEngine;
using Entities;
using Services;

namespace Reactions
{
    public class BirdFearOfCollisionReaction : Reaction
    {
        private Animator _animator;

        public BirdFearOfCollisionReaction(Bird bird) => _animator = bird.GetComponentInChildren<Animator>();

        public override void React()
        {
            _animator.Play(AnimationService.States.FearOfCollision);
            Debug.Log("ScreamingBird!");
        } 
    }
}
