using System.Collections;
using UnityEngine;

namespace Assets.Scripts
{
    public class LeanOutingWindowReaction : Reaction
    {
        private NetGuy _netGuy;
        private Animator _animator;
        private float _leanOutingSpeed;

        public LeanOutingWindowReaction(NetGuy netGuy, float leanOutingSpeed)
        {
            _netGuy = netGuy;
            _animator = netGuy.GetComponent<Animator>();
            _leanOutingSpeed = leanOutingSpeed;
        }

        private IEnumerator LeanOut()
        {
            float currentSide = 0;
            float targetSide = -Mathf.Clamp(_netGuy.transform.position.x, -1, 1);

            while (Mathf.Approximately(currentSide, targetSide))
            {
                _animator.SetFloat(AnimationService.Parameters.LeanOutingSide, currentSide);
                currentSide = Mathf.MoveTowards(currentSide, targetSide, _leanOutingSpeed * Time.deltaTime);
                yield return null;
            }

            yield break;
        }

        public override void React() => _netGuy.StartCoroutine(LeanOut());
    }
}
