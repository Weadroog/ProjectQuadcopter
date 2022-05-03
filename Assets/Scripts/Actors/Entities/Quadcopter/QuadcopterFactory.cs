using UnityEngine;

namespace Assets.Scripts
{
    class QuadcopterFactory : ActorFactory<Quadcopter, QuadcopterConfig>
    {
        private WayMatrix _wayMatrix = new WayMatrix();

        public QuadcopterFactory(QuadcopterConfig config, Container container) : base(config, container) { }

        public override Quadcopter GetCreated()
        {
            Quadcopter quadcopter = Object.Instantiate(_config.Prefab, _container.transform);
            SwipeController swipeController = quadcopter.gameObject.AddComponent<SwipeController>();
            Health health = quadcopter.gameObject.AddComponent<Health>();
            swipeController.SetStartPosition(MatrixPosition.DownLeft);
            swipeController.SetMotionDuration(_config.MotionDuration);
            health.SetMaxHP(_config.HP);
            return quadcopter;
        }
    }
}
