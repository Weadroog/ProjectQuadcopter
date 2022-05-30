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

            quadcopter.gameObject
                .AddComponent<SwipeController>()
                .SetStartablePosition(MatrixPosition.Center)
                .SetMotionDuration(_config.MotionDuration);

            Lifer lifer = quadcopter.gameObject.AddComponent<Lifer>();
            lifer.OnChanged += _lifeCounter.Display;
            lifer.SetMaxLifes(_config.Lives);

            Charger charger = quadcopter.gameObject.AddComponent<Charger>();
            charger.OnChanged += _chargeCounter.Display;
            charger.SetMaxCharge(_config.Charge);
            charger.SetDecreaseTime(_config.ChargeDecreaseTime);

            quadcopter.AddReaction<CollisionDetector, AggressiveBird, Car, Net, Clothesline>(new TakeDamageReaction(lifer));
            quadcopter.AddReaction<CollisionDetector, Battery>(new RechargeReaction(charger));

            return quadcopter;
        }
    }
}
