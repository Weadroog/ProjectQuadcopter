using UnityEngine;
using Components;
using Reactions;

namespace Entities
{
    public class ClientFactory : EntityFactory<Client, ClientConfig>
    {
        public ClientFactory(ClientConfig config) : base(config) { }

        public override Client GetCreated()
        {
            Client client = Object.Instantiate(_config.Prefab);

            client.gameObject.AddComponent<Disappearer>().OnDisappear += Deliverer.OnDeliverySequenceFailed.Invoke;

            CollisionDetector collisionDetector = client.AddReaction<CollisionDetector, Pizza>(new SuccessfulDeliveryReaction(client));
            collisionDetector.Receive(_config);

            client.gameObject
                .AddComponent<Mover>()
                .Receive(_config);

            Deliverer.OnDeliverySequenceFailed += () => {
                client.gameObject.SetActive(false);
                Debug.Log("Клиент больше не ждет пиццу");
            };
            return client;
        }
    }
}
