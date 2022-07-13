using UnityEngine;

namespace Assets.Scripts
{
    public class AggressiveBirdKillingReaction : Reaction
    {
        private Bird _bird;
        private ParticleSystem _particleSystem;
        private Animator _animator;

        public AggressiveBirdKillingReaction(Bird bird) 
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
