using System.Collections;
using UnityEngine;
using Entities;
using Components;

namespace Reactions
{
    public class TakeDamageReaction : Reaction
    {
        private QuadcopterConfig _config;
        private Lifer _lifer;
        private QuadcopterNextReaction _moveNextReaction;
        private Collider _collider;
        private SwipeController _swipeController;
        private SkinnedMeshRenderer _renderer;

        public TakeDamageReaction(Quadcopter quadcopter, QuadcopterConfig config)
        {
            _config = config;
            _lifer = quadcopter.GetComponent<Lifer>();
            _moveNextReaction = new QuadcopterNextReaction(quadcopter, config);
            _collider = quadcopter.GetComponent<Collider>();
            _swipeController = quadcopter.GetComponent<SwipeController>();
            _renderer = quadcopter.GetComponentInChildren<SkinnedMeshRenderer>();
        }

        public override void React()
        {
            _lifer.TakeDamage();
            _moveNextReaction.React();
            _lifer.StartCoroutine(Immortaling());
            _lifer.StartCoroutine(ControlDisabling());
        }

        private IEnumerator ControlDisabling()
        {
            _swipeController.enabled = false;
            yield return new WaitForSeconds(_config.ImmortalModeTime / 2);
            _swipeController.enabled = true;
            yield break;
        }

        private IEnumerator Immortaling()
        {
            float currentTime = 0;
            float flickeringSpeed = 5f;
            Color defaultColor = _renderer.material.color;

            _collider.enabled = false;

            while (currentTime < _config.ImmortalModeTime)
            {
                _renderer.material.color = new Color(defaultColor.r, defaultColor.g, defaultColor.b, Mathf.PingPong(Time.time * flickeringSpeed, 1)); 
                currentTime += Time.deltaTime;
                yield return null;
            }

            _renderer.material.color = defaultColor;
            _collider.enabled = true;
            yield break;
        }
    }
}
