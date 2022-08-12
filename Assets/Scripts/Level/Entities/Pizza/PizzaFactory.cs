using UnityEngine;
using DG.Tweening;
using Components;
using Reactions;

namespace Entities
{
    public class PizzaFactory : EntityFactory<Pizza, PizzaConfig>
    {
        private Deliverer _deliverer;

        public PizzaFactory(PizzaConfig config, Deliverer deliverer) : base(config) => _deliverer = deliverer;

        public override Pizza GetCreated()
        {
            Pizza pizza = Object.Instantiate(_config.PizzaPrefab);
            pizza.gameObject.SetActive(false);
            pizza.gameObject.AddComponent<Flyer>().Receive(_config);
            pizza.AddReaction<CollisionDetector, Quadcopter>(new GrabPizzaReaction(pizza, _deliverer));
            _deliverer.OnDeliverySequenceFailed += () =>
            {
                DOTween.Kill(pizza);
                pizza.gameObject.SetActive(false); 
            };

            return pizza;   
        }
    }
}
