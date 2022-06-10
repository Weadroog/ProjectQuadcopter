using UnityEngine;

namespace Assets.Scripts
{
    internal class FreezingReaction : Reaction
    {
        public override void React() => Debug.Log("Застыл на месте");
    }
}
