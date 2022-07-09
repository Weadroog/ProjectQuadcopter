using UnityEngine;
using DG.Tweening;

namespace Assets.Scripts
{
    public class QuadcopterNextReaction : Reaction
    {
        private WayMatrix _wayMatrix = new();
        private QuadcopterConfig _config;
        private Quadcopter _quadCopter;
        private SwipeController _swipeController;

        public QuadcopterNextReaction(Quadcopter quadcopter, QuadcopterConfig config)
        {
            _config = config;
            _quadCopter = quadcopter;
            _swipeController = quadcopter.GetComponent<SwipeController>();
        }

        public override void React()
        {
            _quadCopter.transform.position = _wayMatrix.GetPosition(MatrixPosition.Center) + Vector3.back * 20;
            _swipeController.SetPosition(MatrixPosition.Center);
            _quadCopter.transform.DOMove(_wayMatrix.GetPositionByArrayCoordinates(_swipeController.CurrentPosition), _config.MotionDuration * 2);
        }
    }
}
