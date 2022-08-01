using UnityEngine;
using Entities;
using Components;

namespace Reactions
{
    public class GrabPizzaReaction : Reaction
    { 
        private Deliverer _deliverer;
        private Pizza _flyingPizza;

        public GrabPizzaReaction(Pizza pizza, Deliverer deliverer)
        {
            _deliverer = deliverer;
            _flyingPizza = pizza;
        }

        public override void React()
        {
            Debug.Log("Забрали пиццу");
            _flyingPizza.gameObject.SetActive(false);
            _deliverer.GrabPizza();
        }
    }
}

