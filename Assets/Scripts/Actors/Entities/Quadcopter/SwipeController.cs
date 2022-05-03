using UnityEngine;
using DG.Tweening;

namespace Assets.Scripts
{
    public class SwipeController : MonoBehaviour
    {
        private float _motionDuration;
        private WayMatrix _wayMatrix = new WayMatrix();
        private Vector2Int _currentPosition;

        public Vector2Int CurrentPosition
        {
            get => _currentPosition;

            private set => _currentPosition = new Vector2Int(Mathf.Clamp(value.x, 0, _wayMatrix.Width - 1), Mathf.Clamp(value.y, 0, _wayMatrix.Height - 1));
        }

        private void OnEnable() => SwipeHandler.OnSwipe += UpdatePosition;

        public void SetMotionDuration(float motionDuration) => _motionDuration = motionDuration;

        public void SetStartPosition(MatrixPosition position)
        {
            transform.position = _wayMatrix.GetPosition(position, out _currentPosition);
        }

        private void UpdatePosition(Vector2Int positionShift)
        {
            CurrentPosition = new Vector2Int(CurrentPosition.x + positionShift.x, CurrentPosition.y - positionShift.y);
            Move();
        }

        private void Move() => transform.DOMove(_wayMatrix.GetCoordinatePosistion(CurrentPosition), _motionDuration);

        private void OnDisable() => SwipeHandler.OnSwipe -= UpdatePosition;
    }
}