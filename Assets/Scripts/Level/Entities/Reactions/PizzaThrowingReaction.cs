using UnityEngine;
using System.Collections;
using Entities;
using Components;

namespace Reactions
{
    public class PizzaThrowingReaction : Reaction
    {
        private readonly Deliverer _deliverer;
        private readonly Pizza _flyingPizza;
        private readonly PizzaPoint _pizzaPoint;
        private readonly PizzaGuy _pizzaGuy;

        public PizzaThrowingReaction(Deliverer deliverer, Pizza pizza, PizzaPoint pizzaPoint, PizzaGuy pizzaGuy)
        {
            _flyingPizza = pizza;
            _deliverer = deliverer;
            _pizzaPoint = pizzaPoint;
            _pizzaGuy = pizzaGuy;
        }

        public override void React()
        {
            Debug.Log($"Бросаем пиццу в {_detectableEntity.name} (спавнпоинт: {_pizzaPoint.transform.position}, пицца: {_flyingPizza.gameObject.name})");
            _pizzaGuy.StartCoroutine(ThrowingRoutine());
        }


        private IEnumerator ThrowingRoutine()
        {
            _flyingPizza.transform.position = _pizzaPoint.transform.position;
            yield return new WaitForEndOfFrame();
            Debug.Log($"положение пиццы {_flyingPizza.transform.position}");
            _flyingPizza.gameObject.SetActive(true);
            _deliverer.ThrowPizza();
        }
        
    }
}

