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

            Disappearer disappearer = battery.gameObject.AddComponent<Disappearer>();
            disappearer.SetDisappearPoint(_wayMatrix.DisappearPoint);

            Rotator rotator = battery.gameObject.AddComponent<Rotator>();
            rotator.SetRotationSpeed(_config.RotationSpeed);

            Mover mover = battery.gameObject.AddComponent<Mover>();

            battery.AddReaction<CollisionDetector, Quadcopter>(new BatteryDisappearReaction(battery));
            battery.AddReaction<BackDetector, AggressiveBird, Car>(new PushForwardReaction(mover)).SetDetectionDistance(10f);



            return battery;
        }
    }
}
