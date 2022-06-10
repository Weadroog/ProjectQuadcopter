using UnityEngine;

namespace Assets.Scripts
{
    public class AggressiveBirdKillingReaction : Reaction
    {
        public override void React() => Debug.Log("Умер с распылением перьев");
    }
}
