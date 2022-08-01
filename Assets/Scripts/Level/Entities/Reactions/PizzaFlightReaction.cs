using Entities;
using DG.Tweening;
using Services;

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

        public override void React() => UpdateService.OnFixedUpdate += MovePizza;
        
        private void MovePizza()
        {
            if(_pizza.transform.position != _quadcopter.transform.position)
                _pizza.transform.DOMove(_quadcopter.transform.position, _pizzaFlightTime);
            else UpdateService.OnFixedUpdate -= MovePizza;
        }
    }

}
