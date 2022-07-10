using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    public class FailedDeliveryReaction : Reaction
    {
        public FailedDeliveryReaction() { }

        public override void React()
        {
            Debug.Log("Сбросили питсу: пролетели клиента");
            Deliverer.OnDeliverySequenceFailed?.Invoke();
        }
    }

}

