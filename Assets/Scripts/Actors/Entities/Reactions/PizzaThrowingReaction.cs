using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    public class PizzaThrowingReaction : Reaction
    {
        private Pizza _pizza;
        //private Quadcopter _quadcopter;

        public PizzaThrowingReaction(Pizza pizza)
        {
            _pizza = pizza;
        }

        public override void React()
        {
            _pizza.transform.position = _detectableEntity.transform.position;
            Debug.Log($"Throwing Pizza ({_detectableEntity.name})");
        }
    }
}

