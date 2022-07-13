using UnityEngine;

namespace Assets.Scripts
{
    class BirdFactory : EntityFactory<Bird, BirdConfig>
    {
        private WayMatrix _wayMatrix = new();

        public BirdFactory(BirdConfig config) : base(config) { }

        public override Bird GetCreated()
        {
            Bird bird = Object.Instantiate(_config.Prefab);

            bird.gameObject.AddComponent<Mover>().Receive(_config);

            Disappearer disappearer = bird.gameObject.AddComponent<Disappearer>();
            disappearer.SetDisappearPoint(_wayMatrix.DisappearPoint);

            bird.AddReaction<CollisionDetector, Quadcopter, Car>(new AggressiveBirdKillingReaction(bird));
            bird.AddReaction<CollisionDetector, NetGuy>(new FreezingReaction());
            bird.GetComponent<Animator>().keepAnimatorControllerStateOnDisable = true;

            return bird;
        }
    }
}
