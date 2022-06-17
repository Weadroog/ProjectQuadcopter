using UnityEngine;

namespace Assets.Scripts
{
    public class NetCatchingReaction : Reaction
    {
        public NetCatchingReaction() { }

        public override void React()
        {
            Debug.Log("Поймал!");
        }
    }
}
