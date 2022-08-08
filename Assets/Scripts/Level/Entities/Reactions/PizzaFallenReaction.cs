using UnityEngine;
using Components;

namespace Reactions
{

    public class PizzaFallenReaction : Reaction
    {
        private Deliverer _deliverer;

        public PizzaFallenReaction(Deliverer deliverer)
        {
            _deliverer = deliverer;
        }

        public override void React()
        {
            if (_deliverer.IsCarryingPizza || _deliverer.IsPizzaThrown)
            {
                _deliverer.DropPizza();
                Debug.Log("Уронили питсу");
            }
            
        }
    }
}

