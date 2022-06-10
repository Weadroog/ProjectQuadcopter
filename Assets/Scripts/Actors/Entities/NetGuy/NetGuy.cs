using UnityEngine;

namespace Assets.Scripts
{
    public class NetGuy : Entity 
    {
        private float _actionSide;

        public float ActionSide => _actionSide;

        private void OnEnable()
        {
            _actionSide = -Mathf.Clamp(transform.position.x, -1, 1);
        }
    }
}