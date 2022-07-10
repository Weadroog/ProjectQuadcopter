using System;
using UnityEngine;

namespace Assets.Scripts
{
    public class Deliverer : MonoBehaviour
    {
        [SerializeField] private bool _isCarryingPizza;

        public static Action OnSuccessfulDelivery;
        public static Action OnDeliverySequenceFailed;
        public static Action OnPizzaGrabbed;

        public bool IsCarryingPizza => _isCarryingPizza;

        private void OnEnable() {
            OnSuccessfulDelivery += () => _isCarryingPizza = false;
            OnDeliverySequenceFailed += () => _isCarryingPizza = false;
        }

        public void SetPizzaCarryingStatus(bool isCarryingPizza) => _isCarryingPizza = isCarryingPizza;
        
    }
}