using UnityEngine;

namespace Assets.Scripts
{
    public class CarBeepReaction : Reaction
    {
        public override void React() => Debug.Log("Beeeep");
    }
}
