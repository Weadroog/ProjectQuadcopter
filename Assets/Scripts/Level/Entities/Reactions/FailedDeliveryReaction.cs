using UnityEngine;
using Components;

namespace Reactions
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

