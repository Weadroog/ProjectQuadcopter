using System.Collections;
using UnityEngine;

namespace Assets.Scripts
{
    public class ShoveOutReaction : Reaction
    {
        private NetGuy _netGuy;
        private NetGuyConfig _config;
        private Animator _animator;

        public ShoveOutReaction(NetGuy netGuy, NetGuyConfig config)
        {
            _netGuy = netGuy;
            _config = config;
            _animator = netGuy.GetComponent<Animator>();
        }

        private IEnumerator ShoveOut()
        {
            float currentSide = 0;
            float targetSide = -Mathf.Clamp(_netGuy.transform.position.x, -1, 1);

            while (currentSide != targetSide)
            {
                Debug.Log("ShoveOut");
                _animator.SetFloat(AnimationService.Parameters.Side, currentSide);
                currentSide = Mathf.MoveTowards(currentSide, targetSide, _config.ShoveInSpeed * Time.deltaTime);
                yield return null;
            }

            yield break;
        }

        public override void React() => _netGuy.StartCoroutine(ShoveOut());
    }
}
