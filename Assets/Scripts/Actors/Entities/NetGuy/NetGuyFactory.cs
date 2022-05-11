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
            netGuy.gameObject.AddComponent<Disappearer>().SetDisappearPoint(new Vector3(0, 0, -20));
            netGuy.AddReaction<CollisionDetector, Quadcopter, AggressiveBird>(new NetCatchReaction());
            RadiusableDetector radiusableDetector = netGuy.AddReaction<RadiusableDetector, Quadcopter>(new LeanOutWindowReaction(netGuy));
            radiusableDetector.SetRadius(_config.DetectionRadius, _config.SemiMajorAxis);
            return netGuy;
        }
    }
}
