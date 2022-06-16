using UnityEngine;

namespace Assets.Scripts
{
    public class AggressiveBirdKillingReaction : Reaction
    {
        private AggressiveBird _aggressiveBird;
        private ParticleSystem _aggressiveBirdParticleSystem;

        public AggressiveBirdKillingReaction(AggressiveBird aggressiveBird) 
        {
            _aggressiveBird = aggressiveBird;
            _aggressiveBirdParticleSystem = _aggressiveBird.GetComponentInChildren<ParticleSystem>();
        }

        public override void React() 
        {
            _aggressiveBirdParticleSystem.Play();
        }
    }
}
