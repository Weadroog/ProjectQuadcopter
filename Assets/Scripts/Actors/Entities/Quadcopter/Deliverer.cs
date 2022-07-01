using System;
using UnityEngine;

namespace Assets.Scripts
{
    public class Deliverer : MonoBehaviour
    {
        [SerializeField] private DeliveryState _deliveryState;

        public static event Action<DeliveryState> OnDeliveryStateChanged;
        public static Action<DeliveryState> OnDeliveryEventOccured;

        private void OnEnable() => OnDeliveryEventOccured += SetDeliveryState;

        public DeliveryState DeliveryState
        {
            get => _deliveryState;
            private set
            {
                _deliveryState = value;
                OnDeliveryStateChanged?.Invoke(_deliveryState);
            }
        }

        public void SetDeliveryState(DeliveryState deliveryState) => DeliveryState = deliveryState;
        
        private void OnDisable() => OnDeliveryEventOccured -= SetDeliveryState;
    }

    public enum DeliveryState
    {
        CarryingPizza,
        NotCarryingPizza
    }
}