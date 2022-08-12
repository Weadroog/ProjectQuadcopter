using System;
using UnityEngine;
using General;
using Entities;

namespace Components
{
    public class Deliverer : ConfigReceiver<QuadcopterConfig>
    {
        public event Action OnSuccessfulDelivery;
        public event Action OnDeliverySequenceFailed;
        public event Action OnPizzaThrown;
        public event Action OnPizzaGrabbed;
        public event Action OnPizzeriaRequested;

        private bool _isCarryingPizza = false;
        private bool _isPizzaThrown = false;

        public bool IsCarryingPizza => _isCarryingPizza;
        public bool IsPizzaThrown => _isPizzaThrown;

        private void Start() => OnPizzeriaRequested?.Invoke();

        public void GrabPizza()
        {
            _isCarryingPizza = true;
            _isPizzaThrown = false;
            OnPizzaGrabbed?.Invoke();
        }

        public void ThrowPizza()
        {
            _isPizzaThrown = true;
            OnPizzaThrown?.Invoke();
        }
        
        public void DropPizza(bool isDeliverySuccseeded = false)
        {
            if (isDeliverySuccseeded)
                OnSuccessfulDelivery?.Invoke();
            else
                OnDeliverySequenceFailed?.Invoke();

            _isPizzaThrown = false;
            _isCarryingPizza = false;

            OnPizzeriaRequested?.Invoke();
        }

        public void SetPizzaCarryingStatus(bool isCarryingPizza) => _isCarryingPizza = isCarryingPizza;

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.blue;
            Gizmos.DrawSphere(_config.PizzaConnectionPoint + transform.position, 0.3f);
        }

    }
}
 