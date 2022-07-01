using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    public class FailedDeliveryReaction : Reaction
    {
        public FailedDeliveryReaction() {  }

        public override void React()
        {
            Debug.Log("Сбросили питсу: не подобрали заказ / пролетели клиента / потеряли питсу");
            Deliverer.OnDeliveryEventOccured?.Invoke(DeliveryState.NotCarryingPizza);
        }
    }

}

