using Components;
using UnityEngine;
using Reactions;

namespace Entities
{
    public class PizzaFactory : EntityFactory<Pizza, PizzaConfig>
    {
        private Deliverer _deliverer;
        private Quadcopter _quadcopter;

        public PizzaFactory(PizzaConfig config, Deliverer deliverer, Quadcopter quadcopter) : base(config)
        {
            _deliverer = deliverer;
            _quadcopter = quadcopter;
        }

        public override Pizza GetCreated()
        {
            Pizza pizza = Object.Instantiate(_config.PizzaPrefab);
            pizza.gameObject.SetActive(false);
            pizza.AddReaction<CollisionDetector, Quadcopter>(new GrabPizzaReaction(pizza, _deliverer));
            _deliverer.OnPizzaThrown += new PizzaFlightReaction(pizza, _quadcopter, _config.PizzaFlightTime).React;
            return pizza;
        }
    }
}
