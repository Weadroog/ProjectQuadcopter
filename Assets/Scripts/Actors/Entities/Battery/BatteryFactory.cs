using UnityEngine;

namespace Assets.Scripts
{
    class BatteryFactory : EntityFactory<Battery, BatteryConfig>
    {
        private WayMatrix _wayMatrix = new();

        public BatteryFactory(BatteryConfig config) : base(config) { }

        public override Battery GetCreated()
        {
            Battery battery = Object.Instantiate(_config.Prefab);
            Mover mover = battery.gameObject.AddComponent<Mover>();
            mover.Receive(_config);

            battery.gameObject.AddComponent<Rotator>().Receive(_config);
            battery.gameObject.AddComponent<Disappearer>().SetDisappearPoint(_wayMatrix.DisappearPoint);

            battery.AddReaction<CollisionDetector, Quadcopter>(new BatteryDisappearReaction(battery));
            battery.AddReaction<BackDetector, AggressiveBird, Car>(new PushForwardReaction(mover)).Receive(_config);
            return battery;
        }
    }
}
