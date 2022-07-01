using System;
using UnityEngine;

namespace Assets.Scripts
{
    public class Deliverer : MonoBehaviour
    {
        [SerializeField] private DeliveryState _deliveryState;

        public static event Action<DeliveryState> OnDeliveryStateChanged;
        public static Action<DeliveryState> OnDeliveryEventOccured;
        public static Action OnPizzeriaBypassed;

        private void OnEnable() => OnDeliveryEventOccured += SetDeliveryState;

        public DeliveryState DeliveryState
        {
            get => _deliveryState;
            private set
            {
                if(value != _deliveryState) OnDeliveryStateChanged?.Invoke(value);
                _deliveryState = value;
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