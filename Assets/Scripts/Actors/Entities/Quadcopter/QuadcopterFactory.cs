using UnityEngine;

namespace Assets.Scripts
{
    public class QuadcopterFactory : EntityFactory<Quadcopter, QuadcopterConfig>
    {
        private LifeCounter _lifeCounter;
        private ChargeCounter _chargeCounter;
        private MoneyCounter _moneyCounter;

        public QuadcopterFactory(QuadcopterConfig config, Container container, LifeCounter lifeCounter, ChargeCounter chargeCounter, MoneyCounter moneyCounter) : base(config, container) 
        {
            _lifeCounter = lifeCounter;
            _chargeCounter = chargeCounter;
            _moneyCounter = moneyCounter;
        }

        public override Quadcopter GetCreated()
        {
            Quadcopter quadcopter = Object.Instantiate(_config.Prefab, _container.transform);
            GameStopper.OnPlay += () => quadcopter.gameObject.SetActive(true);

            SwipeController swipeController = quadcopter.gameObject
                .AddComponent<SwipeController>()
                .SetStartablePosition(MatrixPosition.Center);

            GameStopper.OnPlay += () => swipeController.enabled = true;

            swipeController.Receive(_config);
            swipeController.enabled = false;

            Lifer lifer = quadcopter.gameObject.AddComponent<Lifer>();
            lifer.OnChanged += _lifeCounter.Display;
            lifer.Receive(_config);
            lifer.Restore();

            Purse purse = quadcopter.gameObject.AddComponent<Purse>();
            purse.OnChanged += _moneyCounter.Display;
            purse.Receive(_config);

            Deliverer deliverer = quadcopter.gameObject.AddComponent<Deliverer>();
            deliverer.SetPizzaCarryingStatus(false);

            quadcopter.AddReaction<CollisionDetector, Bird, Car, Net>(new PizzaFallenReaction(deliverer));
            quadcopter.AddReaction<CollisionDetector, Bird, Car, Net>(new TakeDamageReaction(quadcopter, _config));

            GameStopper.OnPlay += new QuadcopterNextReaction(quadcopter, _config).React;

            return quadcopter;
        }
    }
}
