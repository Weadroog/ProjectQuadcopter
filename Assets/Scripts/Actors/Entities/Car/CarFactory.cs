using UnityEngine;

namespace Assets.Scripts
{
    class CarFactory : ActorFactory<Car, CarConfig>
    {
        private Quadcopter _quadcopter;

        public CarFactory(CarConfig config, Quadcopter quadcopter) : base(config) => _quadcopter = quadcopter;

        public override Car GetCreated()
        {
            Car car = Object.Instantiate(_config.Prefab);
            car.gameObject.AddComponent<Mover>().SetSelfSpeed(_config.MoveSpeed);
            car.gameObject.AddComponent<Disappearer>();
            car.AddReaction<CollisionDetector>(new KnockedDownReaction(_quadcopter));
            car.AddReaction<VisibilityRangeDetector>(new LookObstaclesReaction()).SetRange(_config.VisibilDetector);
            return car;
        }
    }
}
