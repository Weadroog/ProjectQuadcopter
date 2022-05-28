using UnityEngine;

namespace Assets.Scripts
{
    class AggressiveBirdFactory : ActorFactory<AggressiveBird, AggressiveBirdConfig>
    {
        public AggressiveBirdFactory(AggressiveBirdConfig config) : base(config) { }

        public override AggressiveBird GetCreated()
        {
            AggressiveBird aggressiveBird = Object.Instantiate(_config.Prefab);
            Mover mover = aggressiveBird.gameObject.AddComponent<Mover>();
            Disappearer disappearer = aggressiveBird.gameObject.AddComponent<Disappearer>();
            aggressiveBird.AddReaction<CollisionDetector, Quadcopter, Car>(new AggressiveBirdKillingReaction());
            aggressiveBird.AddReaction<CollisionDetector, NetGuy>(new FreezingReaction());
            mover.SetSelfSpeed(_config.SelfSpeed);
            disappearer.SetDisappearPoint(new Vector3(0, 0, -20));
            return aggressiveBird;
        }
    }
}
