using Entities;
using DG.Tweening;
using Services;

namespace Reactions
{
    public class PizzaFlightReaction : Reaction
    {
        private Pizza _pizza;
        private Quadcopter _quadcopter;

        public PizzaFlightReaction(Pizza pizza, Quadcopter quadcopter)
        {
            _pizza = pizza;
            _quadcopter = quadcopter;
        }

        public override void React() => UpdateService.OnFixedUpdate += MovePizza;
        
        
        private void MovePizza()
        {
            if(_pizza.transform.position != _quadcopter.transform.position)
                _pizza.transform.DOMove(_quadcopter.transform.position, 1);
            else UpdateService.OnFixedUpdate -= MovePizza;
        }
    }

}
