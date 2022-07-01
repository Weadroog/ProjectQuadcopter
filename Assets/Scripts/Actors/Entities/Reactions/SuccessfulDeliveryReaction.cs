using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    public class SuccessfulDeliveryReaction : Reaction
    {
        public override void React()
        {
            Debug.Log("Удачно доставили питсу, спавним новую пиццерию");
            Deliverer.OnDeliveryEventOccured?.Invoke(DeliveryState.NotCarryingPizza);
        }
    }

}

