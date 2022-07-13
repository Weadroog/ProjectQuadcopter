using UnityEngine;
using Entities;

namespace Reactions
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
