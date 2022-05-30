using UnityEngine;

namespace Assets.Scripts
{
    public class NetFallReaction : Reaction
    {
        private Animator _animator;

        public NetFallReaction(NetGuy netGuy) => _animator = netGuy.GetComponent<Animator>();

        public override void React()
        {

        }
    }
}
