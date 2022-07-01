using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
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
            if (_deliverer.DeliveryState == DeliveryState.CarryingPizza)
            {
                Deliverer.OnDeliveryEventOccured?.Invoke(DeliveryState.NotCarryingPizza);
                Debug.Log("Уронили питсу");
            }
            
            
        }
    }
}

