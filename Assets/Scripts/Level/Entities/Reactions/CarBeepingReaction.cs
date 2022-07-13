using UnityEngine;

namespace Reactions
{
    public class CarBeepingReaction : Reaction
    {
        public override void React() => Debug.Log("Beeeep");
    }
}
