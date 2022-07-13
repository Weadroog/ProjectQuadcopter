using UnityEngine;

namespace Reactions
{
    internal class FreezingReaction : Reaction
    {
        public override void React() => Debug.Log("Застыл на месте");
    }
}
