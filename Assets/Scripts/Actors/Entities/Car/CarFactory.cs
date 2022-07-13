using UnityEngine;

namespace Assets.Scripts
{
    class CarFactory : EntityFactory<Car, CarConfig>
    {
        private WayMatrix _wayMatrix = new();

        public CarFactory(CarConfig config) : base(config) { }

        public override Car GetCreated()
        {
            Car car = Object.Instantiate(_config.Prefab);
            car.gameObject.AddComponent<Mover>().Receive(_config);

            car.gameObject.AddComponent<Disappearer>().SetDisappearPoint(_wayMatrix.DisappearPoint);
            car.AddReaction<CollisionDetector, Quadcopter, Bird>(new CarCrashingReaction());
            return car;
        }
    }
}
