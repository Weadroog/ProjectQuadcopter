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

        public QuadcopterFactory(QuadcopterConfig config, Container container, LifeCounter lifeCounter, MoneyCounter moneyCounter) : base(config, container) 
        {
            _lifeCounter = lifeCounter;
            _moneyCounter = moneyCounter;
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

            quadcopter.AddReaction<CollisionDetector, Bird, Car, Net>(new PizzaFallenReaction(deliverer));
            quadcopter.AddReaction<CollisionDetector, Bird, Car, Net>(new TakeDamageReaction(quadcopter, _config));

            GameFlowService.OnPlay += new QuadcopterNextReaction(quadcopter, _config).React;

            return quadcopter;
        }
    }
}
