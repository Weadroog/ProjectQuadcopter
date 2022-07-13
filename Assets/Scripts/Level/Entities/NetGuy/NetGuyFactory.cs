using UnityEngine;
using Services;
using Components;
using Reactions;

namespace Entities
{
    class NetGuyFactory : EntityFactory<NetGuy, NetGuyConfig>
    {
        public NetGuyFactory(NetGuyConfig config) : base(config) { }

        public override NetGuy GetCreated()
        {
            NetGuy netGuy = Object.Instantiate(_config.NetGuyPrefab);
            Animator animator =  netGuy.GetComponent<Animator>();
            animator.keepAnimatorControllerStateOnDisable = true;

            netGuy.gameObject.AddComponent<Mover>().Receive(_config);

            netGuy.gameObject
                .AddComponent<Disappearer>()
                .OnDisappear += () => netGuy.GetComponent<Animator>().SetFloat(AnimationService.Parameters.Side, 0);

            netGuy
                .AddReaction<BoxDetector, Quadcopter>(new ShoveOutReaction(netGuy, _config))
                .Receive(_config);

            netGuy.gameObject
                .AddComponent<NetEquiper>()
                .Receive(_config);

            return netGuy;
        }
    }
}
