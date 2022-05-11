using UnityEngine;

namespace Assets.Scripts
{
    public class AggressiveBirdKillReaction : Reaction
    {
        public override void React() => Debug.Log("Умер с распылением перьев");
    }
}
