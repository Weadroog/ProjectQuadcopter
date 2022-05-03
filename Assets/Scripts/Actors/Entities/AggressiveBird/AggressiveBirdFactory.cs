using UnityEngine;

namespace Assets.Scripts
{
    class AggressiveBirdFactory : ActorFactory<AggressiveBird, AggressiveBirdConfig>
    {
        private Quadcopter _quadcopter;

        public AggressiveBirdFactory(AggressiveBirdConfig config, Quadcopter quadcopter) : base(config) => _quadcopter = quadcopter;

        public override AggressiveBird GetCreated()
        {
            AggressiveBird aggressiveBird = Object.Instantiate(_config.Prefab);
            aggressiveBird.gameObject.AddComponent<Mover>().SetSelfSpeed(_config.MoveSpeed);
            aggressiveBird.gameObject.AddComponent<Disappearer>();
            aggressiveBird.AddReaction<CollisionDetector>(new CausingDamage(_quadcopter));
            aggressiveBird.AddReaction<VisibilityRangeDetector>(new LookObstaclesReaction()).SetRange(_config.VisibilDetector);
            return aggressiveBird;
        }
    }
}
