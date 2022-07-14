using System;
using UnityEngine;

namespace Components
{
    public class Deliverer : MonoBehaviour
    {
        private bool _isCarryingPizza = false;

        public event Action OnSuccessfulDelivery;
        public event Action OnDeliverySequenceFailed;
        public event Action OnPizzaGrabbed;
        public event Action OnPizzeriaRequested;

        public bool IsCarryingPizza => _isCarryingPizza;

        //private void OnEnable() {
        //    OnSuccessfulDelivery += () => _isCarryingPizza = false;
        //    OnDeliverySequenceFailed += () => _isCarryingPizza = false;
        //}

        public void GrabPizza()
        {
            _isCarryingPizza = true;
            OnPizzaGrabbed.Invoke();
        }
        
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
        
    }
}