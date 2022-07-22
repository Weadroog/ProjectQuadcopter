using Services;
using Entities;
using Components;

namespace Reactions
{
    public class TakeDamageReaction : Reaction
    {
        private Lifer _lifer;
        private QuadcopterNextReaction _moveNextReaction;

        public TakeDamageReaction(Quadcopter quadcopter, QuadcopterConfig config)
        {
            _lifer = quadcopter.GetComponent<Lifer>();
            _moveNextReaction = new(quadcopter, config);
        }

        public override void React()
        {
            _lifer.TakeDamage();
            //Кат сцена
            //GlobalSpeedService.Stop();
            _moveNextReaction.React();
        }
    }
}
