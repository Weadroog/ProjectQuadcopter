using System;
using UnityEngine;
using General;
using Entities;

namespace Components
{
    public class Deliverer : ConfigReceiver<QuadcopterConfig>
    {
        private bool _isCarryingPizza = false;

        public event Action OnSuccessfulDelivery;
        public event Action OnDeliverySequenceFailed;
        public event Action OnPizzaThrown;
        public event Action OnPizzaGrabbed;
        public event Action OnPizzeriaRequested;

        public bool IsCarryingPizza => _isCarryingPizza;

        private void Start() => OnPizzeriaRequested?.Invoke();
        
        public void GrabPizza()
        {
            _isCarryingPizza = true;
            OnPizzaGrabbed?.Invoke();
        }

        public void ThrowPizza() => OnPizzaThrown?.Invoke();
        
        public void DropPizza(bool isDeliverySuccseeded = false)
        {
            if (isDeliverySuccseeded)
                OnSuccessfulDelivery?.Invoke();
            else
                OnDeliverySequenceFailed?.Invoke();

            OnPizzeriaRequested?.Invoke();
            _isCarryingPizza = false;
        }

        public void SetPizzaCarryingStatus(bool isCarryingPizza) => _isCarryingPizza = isCarryingPizza;

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.blue;
            Gizmos.DrawSphere(_config.PizzaConnectionPoint + transform.position, 0.3f);
        }

    }
}
 