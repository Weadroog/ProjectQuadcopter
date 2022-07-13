using UnityEngine;
using Components;
using Reactions;

namespace Entities
{
    class BatteryFactory : EntityFactory<Battery, BatteryConfig>
    {
        public BatteryFactory(BatteryConfig config) : base(config) { }

        public override Battery GetCreated()
        {
            Battery battery = Object.Instantiate(_config.Prefab);
            Mover mover = battery.gameObject.AddComponent<Mover>();
            mover.Receive(_config);

            battery.gameObject.AddComponent<Rotator>().Receive(_config);
            battery.gameObject.AddComponent<Disappearer>();

            battery.AddReaction<CollisionDetector, Quadcopter>(new BatteryDisappearReaction(battery));
            battery.AddReaction<BackDetector, Bird, Car>(new PushForwardReaction(mover)).Receive(_config);
            return battery;
        }
    }
}
