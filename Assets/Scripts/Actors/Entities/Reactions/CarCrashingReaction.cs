using UnityEngine;

namespace Assets.Scripts
{
    public class CarCrashingReaction : Reaction
    {
        public override void React() => Debug.Log("Разбилось лобовое стекло");
    }
}
