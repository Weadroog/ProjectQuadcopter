using UnityEngine;
using Services;
using Entities;

namespace Reactions
{
    public class BirdKillingReaction : Reaction
    {
        private Bird _bird;
        private ParticleSystem _particleSystem;
        private Animator _animator;

        public BirdKillingReaction(Bird bird) 
        {
            _bird = bird;
            _particleSystem = _bird.GetComponentInChildren<ParticleSystem>();
            _animator = _bird.GetComponent<Animator>();
        }

        public override void React() 
        {
            _particleSystem.Play();
            _animator.Play(AnimationService.States.Fall);
        }
    }
}
