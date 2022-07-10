using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Assets.Scripts
{
    public class GrabPizzaReaction : Reaction
    {
        private Pizza _pizza;

        public GrabPizzaReaction(Pizza pizza)
        {
            _pizza = pizza;
        }

        public override void React()
        {
            Debug.Log("Забрали пиццу");
            _pizza.transform.SetParent(_detectableEntity.transform);
            Deliverer.OnPizzaGrabbed?.Invoke();
            //Deliverer.OnDeliveryEventOccured?.Invoke(DeliveryState.CarryingPizza);
        }
    }
}

