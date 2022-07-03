using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    public class GrabPizzaReaction : Reaction
    {
        public override void React()
        {
            Debug.Log("Забрали пиццу");
            Deliverer.OnDeliveryEventOccured?.Invoke(DeliveryState.CarryingPizza);
        }
    }
}

