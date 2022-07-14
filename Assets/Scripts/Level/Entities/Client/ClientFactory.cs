using UnityEngine;
using Components;
using Reactions;

namespace Entities
{
    public class ClientFactory : EntityFactory<Client, ClientConfig>
    {
        private Deliverer _deliverer;

        public ClientFactory(ClientConfig config, Deliverer deliverer) : base(config)
        {
            _deliverer = deliverer;
        }

        public override Client GetCreated()
        {
            Client client = Object.Instantiate(_config.Prefab);

            client.gameObject.AddComponent<Disappearer>().OnDisappear += () => _deliverer.DropPizza();

            CollisionDetector collisionDetector = client.AddReaction<CollisionDetector, Quadcopter>(new SuccessfulDeliveryReaction(client, _deliverer));
            collisionDetector.Receive(_config);

            client.gameObject
                .AddComponent<Mover>()
                .Receive(_config);

            _deliverer.OnDeliverySequenceFailed += () => {
                client.gameObject.SetActive(false);
                Debug.Log("Клиент больше не ждет пиццу");
            };
            return client;
        }
    }
}
