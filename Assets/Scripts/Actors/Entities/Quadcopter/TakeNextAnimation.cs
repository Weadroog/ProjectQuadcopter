using UnityEngine;

namespace Assets.Scripts
{
    public class TakeNextAnimation : StateMachineBehaviour
    {
        override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) => animator.GetComponent<SwipeController>().enabled = false;

        override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) => animator.GetComponent<SwipeController>().enabled = true;
    }
}