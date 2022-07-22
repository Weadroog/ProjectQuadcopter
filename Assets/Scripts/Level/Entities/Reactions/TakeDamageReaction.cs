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

        public TakeDamageReaction(Quadcopter quadcopter)
        {
            _lifer = quadcopter.GetComponent<Lifer>();
            _renderer = quadcopter.GetComponentInChildren<SkinnedMeshRenderer>();
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
            yield return new WaitForSeconds(1);
            GlobalSpeedService.Instance.enabled = true;
            yield break;
        }
    }
}
