using UnityEngine;
using Entities;
using Components;

namespace Reactions
{
    public class SuccessfulDeliveryReaction : Reaction
    {
        private Client _client;

        public SuccessfulDeliveryReaction(Client client) => _client = client;

        public override void React()
        {
            _detectableEntity.gameObject.SetActive(false);
            _detectableEntity.transform.SetParent(null);
            _client.gameObject.SetActive(false);
            Debug.Log("Удачно доставили питсу, спавним новую пиццерию");
            Deliverer.OnSuccessfulDelivery?.Invoke();
        }
    }

}

