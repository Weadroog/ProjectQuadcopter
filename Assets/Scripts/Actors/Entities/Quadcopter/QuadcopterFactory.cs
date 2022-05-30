using UnityEngine;

namespace Assets.Scripts
{
    class QuadcopterFactory : EntityFactory<Quadcopter, QuadcopterConfig>
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
            SwipeController swipeController = quadcopter.gameObject.AddComponent<SwipeController>();
            Liver liver = quadcopter.gameObject.AddComponent<Liver>();
            Charger charger = quadcopter.gameObject.AddComponent<Charger>();
            quadcopter.AddReaction<CollisionDetector, NetGuy, AggressiveBird, Car>(new TakeDamageReaction(liver));
            quadcopter.AddReaction<CollisionDetector, Battery>(new RechargeReaction(quadcopter));
            swipeController.SetStartablePosition(MatrixPosition.Center);
            swipeController.SetMotionDuration(_config.MotionDuration);
            liver.OnChanged += _lifeCounter.Display;
            liver.SetMaxLives(_config.Lives);
            liver.ResetHP();
            charger.OnChanged += _chargeCounter.Display;
            charger.SetMaxCharge(_config.Charge);
            charger.SetDecreaseTime(_config.ChargeDecreaseTime);
            charger.ChargeUp();

            return quadcopter;
        }
    }
}
