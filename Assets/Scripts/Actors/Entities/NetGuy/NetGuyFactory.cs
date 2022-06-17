using UnityEngine;

namespace Assets.Scripts
{
    class NetGuyFactory : EntityFactory<NetGuy, NetGuyConfig>
    {
        private WayMatrix _wayMatrix = new();

        public NetGuyFactory(NetGuyConfig config) : base(config) { }

        public override NetGuy GetCreated()
        {
            NetGuy netGuy = Object.Instantiate(_config.Prefab);
            netGuy.GetComponent<Animator>().keepAnimatorControllerStateOnDisable = true;
            netGuy.gameObject.AddComponent<Mover>();

            netGuy.gameObject
                .AddComponent<Disappearer>()
                .SetDisappearPoint(_wayMatrix.DisappearPoint);

            netGuy
                .AddReaction<EllipseDetector, Quadcopter>(new LeanOutingWindowReaction(netGuy, _config.LeanOutingSpeed))
                .Receive(_config);

            return netGuy;
        }
    }
}
