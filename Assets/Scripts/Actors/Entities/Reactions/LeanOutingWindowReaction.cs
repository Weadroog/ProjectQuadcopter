using System.Collections;
using UnityEngine;

namespace Assets.Scripts
{
    public class LeanOutingWindowReaction : Reaction
    {
        private NetGuy _netGuy;
        private Animator _animator;
        private float _leanOutingSpeed;
        private float _speedFactor = 0.01f;

        public LeanOutingWindowReaction(NetGuy netGuy, float leanOutingSpeed)
        {
            _netGuy = netGuy;
            _animator = netGuy.GetComponent<Animator>();
            _leanOutingSpeed = leanOutingSpeed * _speedFactor;
        }

        private IEnumerator LeanOut()
        {
            float currentSide = 0;
            float targetSide = -Mathf.Clamp(_netGuy.transform.position.x, -1, 1);

            while (currentSide != targetSide)
            {
                Debug.Log("Leanouting");
                _animator.SetFloat(AnimationService.Parameters.LeanOutingSide, currentSide);
                currentSide = Mathf.Lerp(currentSide, targetSide, _leanOutingSpeed);
                yield return null;
            }

            yield break;
        }

        public override void React() => _netGuy.StartCoroutine(LeanOut());
    }
}
