using UnityEngine;
using Entities;
using Components;

namespace Reactions
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
        }
    }
}

