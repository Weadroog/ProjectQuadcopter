using System.Collections;
using UnityEngine;

namespace Assets.Scripts
{
    public class TakeDamageReaction : Reaction
    {
        private QuadcopterConfig _config;
        private Lifer _lifer;
        private QuadcopterNextReaction _moveNextReaction;
        private Collider _collider;
        private SwipeController _swipeController;

        public TakeDamageReaction(Quadcopter quadcopter, QuadcopterConfig config)
        {
            _config = config;
            _lifer = quadcopter.GetComponent<Lifer>();
            _moveNextReaction = new QuadcopterNextReaction(quadcopter, config);
            _collider = quadcopter.GetComponent<Collider>();
            _swipeController = quadcopter.GetComponent<SwipeController>();
        }

        public override void React()
        {
            _lifer.TakeDamage();
            _moveNextReaction.React();
            _lifer.StartCoroutine(CollisionDisabling());
        }

        private IEnumerator CollisionDisabling()
        {
            _collider.enabled = false;
            _swipeController.enabled = false;
            yield return new WaitForSeconds(_config.ImmortalModeTime);
            _swipeController.enabled = true;
            _collider.enabled = true;
            yield break;
        }
    }
}
