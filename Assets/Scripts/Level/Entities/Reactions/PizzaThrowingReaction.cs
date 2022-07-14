using UnityEngine;
using Entities;

namespace Reactions
{
    public class PizzaThrowingReaction : Reaction
    {
        private Pizza _pizza;

        public PizzaThrowingReaction(Pizza pizza)
        {
            _pizza = pizza;
        }

        public override void React()
        {
            Debug.Log($"Throwing Pizza ({_detectableEntity.name})");
        }
    }
}

