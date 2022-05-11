using UnityEngine;

namespace Assets.Scripts
{
    internal class FreezeReaction : Reaction
    {
        public override void React() => Debug.Log("Застыл на месте");
    }
}
