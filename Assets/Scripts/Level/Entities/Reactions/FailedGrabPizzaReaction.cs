using Components;
using UnityEngine;

namespace Reactions
{
    public class FailedGrabPizzaReaction : Reaction
    {
        private Deliverer _deliverer;

        public FailedGrabPizzaReaction(Deliverer deliverer)
        {
            _deliverer = deliverer;
        }

        public override void React()
        {
            Debug.Log("Не смогли подобрать питсу");
            _deliverer.DropPizza();
        }

    }

}
