using UnityEngine;

namespace Assets.Scripts
{
    public class ClientFactory : EntityFactory<Client, ClientConfig>
    {
        private WayMatrix _wayMatrix = new();

        public ClientFactory(ClientConfig config) : base(config) { }

        public override Client GetCreated()
        {
            Client client = Object.Instantiate(_config.Prefab);

            Disappearer disappearer = client.gameObject
               .AddComponent<Disappearer>()
               .SetDisappearPoint(_wayMatrix.DisappearPoint);

            disappearer.OnDisappear += Deliverer.OnDeliverySequenceFailed.Invoke;

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
