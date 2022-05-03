using UnityEngine;

namespace Assets.Scripts
{
    public class KnockedDownReaction : IReaction
    {
        private Health Health;

        public KnockedDownReaction(Quadcopter quadcopter)
        {
            Health = quadcopter.gameObject.GetComponent<Health>();
        }

        public void SetParametrs(Health health)
        {
            Health = health;
        }
        
        public void React()
        {
            Health.Kill();
        }
    }
}
