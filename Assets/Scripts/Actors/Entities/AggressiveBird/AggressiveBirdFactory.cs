﻿using UnityEngine;

namespace Assets.Scripts
{
    class AggressiveBirdFactory : EntityFactory<AggressiveBird, AggressiveBirdConfig>
    {
        private WayMatrix _wayMatrix = new();

        public AggressiveBirdFactory(AggressiveBirdConfig config) : base(config) { }

        public override AggressiveBird GetCreated()
        {
            AggressiveBird aggressiveBird = Object.Instantiate(_config.Prefab);

            Mover mover = aggressiveBird.gameObject.AddComponent<Mover>();
            mover.SetSelfSpeed(_config.SelfSpeed);

            Disappearer disappearer = aggressiveBird.gameObject.AddComponent<Disappearer>();
            disappearer.SetDisappearPoint(_wayMatrix.DisappearPoint);

            aggressiveBird.AddReaction<CollisionDetector, Quadcopter, Car>(new AggressiveBirdKillingReaction(aggressiveBird));
            aggressiveBird.AddReaction<CollisionDetector, NetGuy>(new FreezingReaction());

            return aggressiveBird;
        }
    }
}
