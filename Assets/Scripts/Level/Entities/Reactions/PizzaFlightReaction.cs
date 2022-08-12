using System.Collections;
using UnityEngine;
using Entities;

namespace Reactions
{
    public class PizzaFlightReaction : Reaction
    {
        private Pizza _pizza;
        private Quadcopter _quadcopter;
        private float _pizzaFlightTime;

        public PizzaFlightReaction(Pizza pizza, Quadcopter quadcopter, float flightTime)
        {
            _pizza = pizza;
            _quadcopter = quadcopter;
            _pizzaFlightTime = flightTime;
        }

        public override void React() => _pizza.StartCoroutine(Flight());

        private IEnumerator Flight()
        {
            while (_pizza.transform.position != _quadcopter.transform.position)
            {
                _pizza.transform.position = Vector3
                    .MoveTowards(_pizza.transform.position, _quadcopter.transform.position, _pizzaFlightTime * Time.deltaTime);

                yield return null;
            }
            yield break;
        }
    }

}
