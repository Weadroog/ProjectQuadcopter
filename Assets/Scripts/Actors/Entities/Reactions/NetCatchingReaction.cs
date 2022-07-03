using System.Collections;
using UnityEngine;

namespace Assets.Scripts
{
    public class NetCatchingReaction : Reaction
    {
        private NetGuy _netGuy;
        private Animator _animator;
        private float _shoveInSpeed;

        public NetCatchingReaction(NetGuy netGuy, float ShoveInSpeed)
        {
            _netGuy = netGuy;
            _animator = netGuy.GetComponent<Animator>();
            _shoveInSpeed = ShoveInSpeed;
        }

        public override void React() => _netGuy.StartCoroutine(ShoveIn());

        private IEnumerator ShoveIn()
        {
            float currentSide = -Mathf.Clamp(_netGuy.transform.position.x, -1, 1);
            float targetSide = 0;

            while (Mathf.Approximately(currentSide, targetSide) == false)
            {
                _animator.SetFloat(AnimationService.Parameters.Side, currentSide);
                currentSide = Mathf.MoveTowards(currentSide, targetSide, _shoveInSpeed * Time.deltaTime);
                yield return null;
            }

            yield break;
        }
    }
}
