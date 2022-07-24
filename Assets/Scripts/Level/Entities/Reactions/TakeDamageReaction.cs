using System.Collections;
using UnityEngine;
using Services;
using Entities;
using Components;

namespace Reactions
{
    public class TakeDamageReaction : Reaction
    {
        private Lifer _lifer;
        private SkinnedMeshRenderer _renderer;
        private SwipeController _swipeController;
        private QuadcopterNextReaction _nextReaction;

        public TakeDamageReaction(Quadcopter quadcopter, QuadcopterConfig config)
        {
            _lifer = quadcopter.GetComponent<Lifer>();
            _renderer = quadcopter.GetComponentInChildren<SkinnedMeshRenderer>();
            _swipeController = quadcopter.GetComponentInChildren<SwipeController>();
            _nextReaction = new QuadcopterNextReaction(quadcopter, config);
        }

        public override void React()
        {
            _lifer.TakeDamage();
            _lifer.StartCoroutine(Focus());
            _renderer.enabled = false;
        }

        private IEnumerator Focus()
        {
            GlobalSpeedService.Instance.enabled = false;
            _swipeController.enabled = false;
            yield return new WaitForSeconds(1);
            _nextReaction.React();
            GlobalSpeedService.Instance.enabled = true;
            yield break;
        }
    }
}
