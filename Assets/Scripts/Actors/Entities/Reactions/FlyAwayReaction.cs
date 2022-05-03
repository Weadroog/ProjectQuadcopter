using UnityEngine;

namespace Assets.Scripts
{
    public class FlyAwayReaction : IReaction
    {
        public FlyAwayReaction()
        {

        }

        public void React()
        {
            Debug.Log("Flew Away");
        }
    }
}
