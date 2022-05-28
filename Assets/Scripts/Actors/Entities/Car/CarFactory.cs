using UnityEngine;

namespace Assets.Scripts
{
    class CarFactory : ActorFactory<Car, CarConfig>
    {
        public CarFactory(CarConfig config) : base(config) { }

        public override Car GetCreated()
        {
            Car car = Object.Instantiate(_config.Prefab);
            car.gameObject.AddComponent<Mover>().SetSelfSpeed(_config.SelfSpeed);
            car.gameObject.AddComponent<Disappearer>().SetDisappearPoint(new Vector3(0, 0, -20));
            car.AddReaction<CollisionDetector, Quadcopter, AggressiveBird>(new CarCrashingReaction());
            return car;
        }
    }
}
