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

            quadcopter.gameObject
                .AddComponent<SwipeController>()
                .SetStartablePosition(MatrixPosition.Center)
                .Receive(_config);

            Lifer lifer = quadcopter.gameObject.AddComponent<Lifer>();
            lifer.OnChanged += _lifeCounter.Display;
            lifer.Receive(_config);
            lifer.Restore();

            Charger charger = quadcopter.gameObject.AddComponent<Charger>();
            charger.OnChanged += _chargeCounter.Display;
            charger.Receive(_config);
            charger.Recharge();

            quadcopter.AddReaction<CollisionDetector, AggressiveBird, Car, Net, Clothesline>(new TakeDamageReaction(lifer));
            quadcopter.AddReaction<CollisionDetector, Battery>(new RechargeReaction(charger));

            return quadcopter;
        }
    }
}
