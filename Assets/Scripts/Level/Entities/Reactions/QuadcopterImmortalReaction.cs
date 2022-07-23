using System.Collections;
using UnityEngine;
using Entities;
using Components;

namespace Reactions
{
    public class QuadcopterImmortalReaction : Reaction
    {
        private QuadcopterConfig _config;
        private Collider _collider;
        private SwipeController _swipeController;
        private SkinnedMeshRenderer _renderer;

        public QuadcopterImmortalReaction(Quadcopter quadcopter, QuadcopterConfig config)
        {
            _config = config;
            _collider = quadcopter.GetComponent<Collider>();
            _swipeController = quadcopter.GetComponent<SwipeController>();
            _renderer = quadcopter.GetComponentInChildren<SkinnedMeshRenderer>();
        }

        public override void React()
        {
            _swipeController.StartCoroutine(Immortaling());
            _swipeController.StartCoroutine(ControlDisabling());
        }

        private IEnumerator ControlDisabling()
        {
            _swipeController.enabled = false;
            yield return new WaitForSeconds(_config.ImmortalModeTime / 5);
            _swipeController.enabled = true;
            yield break;
        }

        private IEnumerator Immortaling()
        {
            _renderer.enabled = true;
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
