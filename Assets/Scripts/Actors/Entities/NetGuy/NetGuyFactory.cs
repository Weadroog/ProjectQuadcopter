using UnityEngine;

namespace Assets.Scripts
{
    class NetGuyFactory : ActorFactory<NetGuy, NetGuyConfig>
    {
        public NetGuyFactory(NetGuyConfig config) : base(config) { }

        public override NetGuy GetCreated()
        {
            NetGuy netGuy = Object.Instantiate(_config.Prefab);
            netGuy.gameObject.AddComponent<Mover>();

            netGuy.gameObject
                .AddComponent<Disappearer>()
                .SetDisappearPoint(new Vector3(0, 0, -20));

            netGuy
                .AddReaction<EllipseDetector, Quadcopter>(new LeanOutingWindowReaction(netGuy, _config.LeanOutingSpeed))
                .SetRadius(_config.DetectionRadius, _config.SemiMajorAxis);

            netGuy.AddReaction<CollisionDetector, Quadcopter, AggressiveBird>(new NetCatchingReaction());
            return netGuy;
        }
    }
}
