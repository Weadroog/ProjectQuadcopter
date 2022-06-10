using UnityEngine;

namespace Assets.Scripts
{
    public class CarBeepingReaction : Reaction
    {
        public override void React() => Debug.Log("Beeeep");
    }
}
