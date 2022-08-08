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

            PizzaFlightReaction flightReaction = new PizzaFlightReaction(pizza, _quadcopter, _config.PizzaFlightTime);
            _deliverer.OnPizzaThrown += flightReaction.Enable;
            _deliverer.OnPizzaGrabbed += flightReaction.Disable;
            _deliverer.OnDeliverySequenceFailed += () =>
            {
                pizza.gameObject.SetActive(false);
                flightReaction.Disable();
            };
            return pizza;   
        }
    }
}
