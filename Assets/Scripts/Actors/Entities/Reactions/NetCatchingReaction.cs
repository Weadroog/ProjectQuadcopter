using UnityEngine;

namespace Assets.Scripts
{
    public class NetCatchingReaction : Reaction
    {
        public override void React() => Debug.Log("Поймал кого-то");
    }
}
