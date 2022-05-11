using UnityEngine;

namespace Assets.Scripts
{
    public class CarCrashReaction : Reaction
    {
        public override void React() => Debug.Log("Разбилось лобовое стекло");
    }
}
