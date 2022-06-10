using UnityEngine;

namespace Assets.Scripts
{
    public class NetCatchingReaction : Reaction
    {
        private NetGuy _netGuy;
        private Animator _animator;

        public NetCatchingReaction(NetGuy netGuy)
        {
            _netGuy = netGuy;
            _animator = netGuy.GetComponent<Animator>();
        }

        public override void React()
        {
            _detectableEntity.transform.SetParent(null);
        }
    }
}
