using UnityEngine;

namespace Assets.Scripts
{
    class NetGuyFactory : ActorFactory<NetGuy, NetGuyConfig>
    {
        private Quadcopter _quadcopter;

        public NetGuyFactory(NetGuyConfig config, Quadcopter quadcopter) : base(config) => _quadcopter = quadcopter;

        public override NetGuy GetCreated()
        {
            NetGuy netGuy = Object.Instantiate(_config.Prefab);
            netGuy.gameObject.AddComponent<Mover>();
            netGuy.gameObject.AddComponent<Disappearer>().SetDisappearPoint(_quadcopter.transform.position + Vector3.back);
            WindowLeanOuter windowLeanOuter = netGuy.gameObject.AddComponent<WindowLeanOuter>();
            netGuy.AddReaction<CollisionDetector>(new KnockedDownReaction(_quadcopter));
            RadiusableDetector radiusDetector = netGuy.AddReaction<RadiusableDetector>(new LeanOutWindowReaction(windowLeanOuter));
            radiusDetector.SetRadius(_config.RangeDetector);
            radiusDetector.SetTarget(_quadcopter);
            return netGuy;
        }
    }
}
