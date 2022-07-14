using UnityEngine;
using Entities;
using Components;

namespace Reactions
{
    public class GrabPizzaReaction : Reaction
    {
        private Pizza _pizza;
        private Deliverer _deliverer;

        public GrabPizzaReaction(Pizza pizza, Deliverer deliverer)
        {
            _pizza = pizza;
            _deliverer = deliverer;
        }

        public override void React()
        {
            Debug.Log("Забрали пиццу");
            _deliverer.GrabPizza();
        }
    }
}

