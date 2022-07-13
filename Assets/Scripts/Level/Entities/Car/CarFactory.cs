using UnityEngine;
using Components;
using Reactions;

namespace Entities
{
    class CarFactory : EntityFactory<Car, CarConfig>
    {
        public CarFactory(CarConfig config) : base(config) { }

        public override Car GetCreated()
        {
            Car car = Object.Instantiate(_config.Prefab);
            car.gameObject.AddComponent<Mover>().Receive(_config);

            car.gameObject.AddComponent<Disappearer>();
            car.AddReaction<CollisionDetector, Quadcopter, Bird>(new CarCrashingReaction());
            return car;
        }
    }
}
