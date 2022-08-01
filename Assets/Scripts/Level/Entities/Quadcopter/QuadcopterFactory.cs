using UnityEngine;
using General;
using Services;
using UI;
using Components;
using Reactions;

namespace Entities
{
    public class QuadcopterFactory : EntityFactory<Quadcopter, QuadcopterConfig>
    {
        private LifeCounter _lifeCounter;
        private MoneyCounter _moneyCounter;
        private Pizza _pizzaPrefab;

        public QuadcopterFactory(QuadcopterConfig config, Container container, LifeCounter lifeCounter, MoneyCounter moneyCounter, Pizza pizzaPrefab) : base(config, container) 
        {
            _lifeCounter = lifeCounter;
            _moneyCounter = moneyCounter;
            _pizzaPrefab = pizzaPrefab;
        }

        public override Quadcopter GetCreated()
        {
            Quadcopter quadcopter = Object.Instantiate(_config.Prefab, _container.transform);
            GameFlowService.OnPlay += () => quadcopter.gameObject.SetActive(true);

            SwipeController swipeController = quadcopter.gameObject.AddComponent<SwipeController>();
            swipeController.Receive(_config);
            swipeController.enabled = false;
            GameFlowService.OnPlay += () => swipeController.enabled = true;

            Lifer lifer = quadcopter.gameObject.AddComponent<Lifer>();
            lifer.OnChanged += _lifeCounter.Display;
            lifer.Receive(_config);
            lifer.Restore();

            Purse purse = quadcopter.gameObject.AddComponent<Purse>();
            purse.OnChanged += _moneyCounter.Display;
            purse.Receive(_config);

            Deliverer deliverer = quadcopter.gameObject.AddComponent<Deliverer>();
            deliverer.Receive(_config);

            Pizza pizza = Object.Instantiate(_pizzaPrefab);
            pizza.transform.SetParent(quadcopter.transform);
            pizza.transform.localPosition = _config.PizzaConnectionPoint;
            pizza.gameObject.SetActive(false);

            deliverer.OnDeliverySequenceFailed += () => pizza.gameObject.SetActive(false);
            deliverer.OnSuccessfulDelivery += () => pizza.gameObject.SetActive(false);
            deliverer.OnPizzaGrabbed += () => pizza.gameObject.SetActive(true);

            quadcopter.AddReaction<CollisionDetector, Bird, Car, Net>(new PizzaFallenReaction(deliverer));
            quadcopter.AddReaction<CollisionDetector, Bird, Car, Net>(new TakeDamageReaction(quadcopter, _config));

            GameFlowService.OnPlay += new QuadcopterNextReaction(quadcopter, _config).React;

            return quadcopter;
        }
    }
}
