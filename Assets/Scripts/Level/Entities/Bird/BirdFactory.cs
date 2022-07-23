using UnityEngine;
using Components;
using Reactions;

namespace Entities
{
    class BirdFactory : EntityFactory<Bird, BirdConfig>
    {
        public BirdFactory(BirdConfig config) : base(config) { }

        public override Bird GetCreated()
        {
            Bird bird = Object.Instantiate(_config.Prefab);

            bird.gameObject.AddComponent<Mover>().Receive(_config);
            bird.gameObject.AddComponent<Disappearer>();

            bird.AddReaction<CollisionDetector, Quadcopter, Car>(new BirdKillingReaction(bird));
            bird.AddReaction<CollisionDetector, NetGuy>(new FreezingReaction());
            bird.GetComponent<Animator>().keepAnimatorControllerStateOnDisable = true;

            return bird;
        }
    }
}
