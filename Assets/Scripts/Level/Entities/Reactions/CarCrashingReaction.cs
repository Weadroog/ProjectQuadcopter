using UnityEngine;

namespace Reactions
{
    public class CarCrashingReaction : Reaction
    {
        public override void React() => Debug.Log("Разбилось лобовое стекло");
    }
}
