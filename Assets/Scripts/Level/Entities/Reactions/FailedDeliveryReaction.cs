using UnityEngine;
using Components;

namespace Reactions
{
    public class FailedDeliveryReaction : Reaction
    {
        private Deliverer _deliverer;

        public FailedDeliveryReaction(Deliverer deliverer)
        {
            _deliverer = deliverer;
        }

        public override void React() => _deliverer.DropPizza();
    }

}

