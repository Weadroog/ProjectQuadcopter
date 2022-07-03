using UnityEngine;

namespace Assets.Scripts
{
    public class QuadcopterFactory : EntityFactory<Quadcopter, QuadcopterConfig>
    {
        private LifeCounter _lifeCounter;
        private ChargeCounter _chargeCounter;

        public QuadcopterFactory(QuadcopterConfig config, Container container, LifeCounter lifeCounter, ChargeCounter chargeCounter) : base(config, container) 
        {
            _lifeCounter = lifeCounter;
            _chargeCounter = chargeCounter;
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

            Charger charger = quadcopter.gameObject.AddComponent<Charger>();
            //charger.OnChanged += _chargeCounter.Display;
            charger.Receive(_config);
            GameStopper.OnPlay += charger.Recharge;

            Deliverer deliverer = quadcopter.gameObject.AddComponent<Deliverer>();
            deliverer.SetDeliveryState(DeliveryState.NotCarryingPizza);

            quadcopter.AddReaction<CollisionDetector, AggressiveBird, Car, Net, Clothesline>(new PizzaFallenReaction(deliverer));
            quadcopter.AddReaction<CollisionDetector, AggressiveBird, Car, Net, Clothesline>(new TakeDamageReaction(quadcopter));
            quadcopter.AddReaction<CollisionDetector, Battery>(new RechargeReaction(charger));

            GameStopper.OnPlay += new QuadcopterNextReaction(quadcopter).React;

            return quadcopter;
        }
    }
}
