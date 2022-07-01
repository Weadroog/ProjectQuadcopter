using System.Collections;
using UnityEngine;

namespace Assets.Scripts
{
    public class ShoveOutReaction : Reaction
    {
        private NetGuy _netGuy;
        private Animator _animator;
        private float _shoveInSpeed;

        public ShoveOutReaction(NetGuy netGuy, float shoveInSpeed)
        {
            _netGuy = netGuy;
            _animator = netGuy.GetComponent<Animator>();
            _shoveInSpeed = shoveInSpeed;
        }

        private IEnumerator ShoveOut()
        {
            float currentSide = 0;
            float targetSide = -Mathf.Clamp(_netGuy.transform.position.x, -1, 1);

            while (Mathf.Approximately(currentSide, targetSide) == false)
            {
                _animator.SetFloat(AnimationService.Parameters.Side, currentSide);
                currentSide = Mathf.MoveTowards(currentSide, targetSide, _shoveInSpeed * Time.deltaTime);
                yield return null;
            }

            yield break;
        }

        public override void React() => _netGuy.StartCoroutine(ShoveOut());
    }
}
