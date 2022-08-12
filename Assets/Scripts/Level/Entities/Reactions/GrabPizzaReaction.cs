using Entities;
using Components;

namespace Reactions
{
    public class GrabPizzaReaction : Reaction
    { 
        private Deliverer _deliverer;
        private Pizza _pizza;

        public GrabPizzaReaction(Pizza pizza, Deliverer deliverer)
        {
            _deliverer = deliverer;
            _pizza = pizza;
        }

        public override void React()
        {
            _detectableEntity.gameObject.SetActive(false);
            _pizza.gameObject.SetActive(true);
            _deliverer.GrabPizza();
        }
    }
}

