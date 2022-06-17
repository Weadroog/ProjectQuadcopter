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
            Animator animator =  netGuy.GetComponent<Animator>();
            animator.keepAnimatorControllerStateOnDisable = true;
            
            netGuy.gameObject.AddComponent<Mover>().Receive(_config);

            netGuy.gameObject
                .AddComponent<Disappearer>()
                .SetDisappearPoint(_wayMatrix.DisappearPoint)
                .OnDisappear += () => animator.SetFloat(AnimationService.Parameters.LeanOutingSide, 0);

            netGuy
                .AddReaction<EllipseDetector, Quadcopter>(new LeanOutingWindowReaction(netGuy, _config.LeanOutingSpeed))
                .Receive(_config);

            return netGuy;
        }
    }
}
