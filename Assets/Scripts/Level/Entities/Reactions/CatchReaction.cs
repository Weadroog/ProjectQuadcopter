﻿using System.Collections;
using UnityEngine;
using Services;
using Entities;

namespace Reactions
{
    public class CatchReaction : Reaction
    {
        private NetGuy _netGuy;
        private Animator _animator;
        private NetGuyConfig _config;
        private Animation _animation;

        public CatchReaction(NetGuy netGuy, NetGuyConfig config)
        {
            _netGuy = netGuy;
            _config = config;
            _animator = netGuy.GetComponent<Animator>();
            _animation = netGuy.GetComponentInChildren<Animation>();
        }

        public override void React() => _netGuy.StartCoroutine(ShoveIn());

        private IEnumerator ShoveIn()
        {
            _animation.Play();
            float currentSide = -Mathf.Clamp(_netGuy.transform.position.x, -1, 1);
            float targetSide = 0;

            while (Mathf.Approximately(currentSide, targetSide) == false)
            {
                _animator.SetFloat(AnimationService.Parameters.Side, currentSide);
                currentSide = Mathf.MoveTowards(currentSide, targetSide, _config.ShoveInSpeed * Time.deltaTime);
                yield return null;
            }

            yield break;
        }
    }
}