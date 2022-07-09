using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

namespace Assets.Scripts
{
    public class SwipeController : ConfigReceiver<QuadcopterConfig>
    {
        private WayMatrix _wayMatrix = new();
        private Vector2Int _currentPosition;
        private Animator _animator;
        private Dictionary<Vector2Int, string> _animations = new();

        public Vector2Int CurrentPosition
        {
            get => _currentPosition;

            private set
            {
                _currentPosition = new Vector2Int
                (
                    Mathf.Clamp(value.x, 0, WayMatrix.Width - 1),
                    Mathf.Clamp(value.y, 0, WayMatrix.Height - 1)
                );
            }
        }

        private void Awake()
        {
            _animator = GetComponentInChildren<Animator>();
            _animations.Add(Vector2Int.up, AnimationService.States.UpStrafe);
            _animations.Add(Vector2Int.down, AnimationService.States.DownStrafe);
            _animations.Add(Vector2Int.left, AnimationService.States.LeftStrafe);
            _animations.Add(Vector2Int.right, AnimationService.States.RightStrafe);
        }

        private void OnEnable() => SwipeHandler.OnSwipe += UpdatePosition;

        public SwipeController SetStartablePosition(MatrixPosition position)
        {
            transform.position = _wayMatrix.GetPosition(position, out _currentPosition);
            return this;
        }

        public void SetPosition(MatrixPosition position) => _wayMatrix.GetPosition(position, out _currentPosition);

        private void UpdatePosition(Vector2Int positionShift)
        {
            CurrentPosition = new Vector2Int(CurrentPosition.x + positionShift.x, CurrentPosition.y - positionShift.y);
            transform.DOMove(_wayMatrix.GetPositionByArrayCoordinates(CurrentPosition), _config.MotionDuration);
            _animator.Play(_animations[positionShift]);
        }

        private void OnDisable() => SwipeHandler.OnSwipe -= UpdatePosition;
    }
}