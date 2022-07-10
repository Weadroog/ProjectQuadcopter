using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
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

