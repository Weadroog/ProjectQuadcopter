﻿using System.Collections;
using UnityEngine;

namespace Assets.Scripts
{
    public class ShoveingInReaction : Reaction
    {
        private NetGuy _netGuy;
        private Animator _animator;
        private NetGuyConfig _config;

        public ShoveingInReaction(NetGuy netGuy, NetGuyConfig config)
        {
            _netGuy = netGuy;
            _config = config;
            _animator = netGuy.GetComponent<Animator>();
        }

        public override void React() => _netGuy.StartCoroutine(ShoveIn());

        private IEnumerator ShoveIn()
        {
            float currentSide = -Mathf.Clamp(_netGuy.transform.position.x, -1, 1);
            float targetSide = 0;

            while (currentSide != targetSide)
            {
                _animator.SetFloat(AnimationService.Parameters.Side, currentSide);
                currentSide = Mathf.MoveTowards(currentSide, targetSide, _config.ShoveInSpeed * Time.deltaTime);
                yield return null;
            }

            yield break;
        }
    }
}
