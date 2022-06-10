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
            battery.gameObject.AddComponent<Mover>();
            battery.AddReaction<CollisionDetector, Quadcopter>(new BatteryDisappearReaction(battery));
            
            disappearer.SetDisappearPoint(_wayMatrix.DisappearPoint);
            return battery;
        }
    }
}
