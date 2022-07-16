using UnityEngine;
using DG.Tweening;
using General;
using Entities;
using Components;

namespace Reactions
{
    public class QuadcopterNextReaction : Reaction
    {
        private WayMatrix _wayMatrix = new();
        private QuadcopterConfig _config;
        private Quadcopter _quadCopter;
        private SwipeController _swipeController;
        private float _takeNextDuration;

        public QuadcopterNextReaction(Quadcopter quadcopter, QuadcopterConfig config)
        {
            _config = config;
            _quadCopter = quadcopter;
            _swipeController = quadcopter.GetComponent<SwipeController>();
            _takeNextDuration = config.MotionDuration * 3;
        }

        public override void React()
        {
            _quadCopter.transform.position = _wayMatrix.GetPosition(MatrixPosition.Center) + Vector3.forward * _wayMatrix.DisappearPoint;
            _swipeController.SetPosition(MatrixPosition.Center);
            DOTween.Kill(_swipeController.transform);
            _quadCopter.transform.DOMove(_wayMatrix.GetPositionByArrayCoordinates(_swipeController.CurrentPosition), _takeNextDuration);
        }
    }
}
