using UnityEngine;
using Entities;
using Components;

namespace Reactions
{
    public class PizzaThrowingReaction : Reaction
    {
        private readonly Deliverer _deliverer;
        private Pizza _flyingPizza;
        private PizzaPoint _pizzaPoint;

        public PizzaThrowingReaction(Deliverer deliverer, Pizza pizza, PizzaPoint pizzaPoint)
        {
            _flyingPizza = pizza;
            _deliverer = deliverer;
            _pizzaPoint = pizzaPoint;
        }

        public override void React()
        {
            Debug.Log($"Бросаем пиццу в {_detectableEntity.name} ({_pizzaPoint.transform.position}, {_flyingPizza.gameObject.name})");
            _flyingPizza.transform.position = _pizzaPoint.transform.position;
            _deliverer.ThrowPizza();
            _flyingPizza.gameObject.SetActive(true);
        }
        
    }
}

