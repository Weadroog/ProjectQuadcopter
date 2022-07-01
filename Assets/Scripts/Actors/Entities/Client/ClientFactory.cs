using System.Collections;
using System.Collections.Generic;
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
            BypassDetector bypassDetector = client.AddReaction<BypassDetector, Quadcopter>(new FailedDeliveryReaction());
            bypassDetector.Receive(_config);

            client.gameObject
               .AddComponent<Disappearer>()
               .SetDisappearPoint(_wayMatrix.DisappearPoint);

            CollisionDetector collisionDetector = client.AddReaction<CollisionDetector, Quadcopter>(new SuccessfulDeliveryReaction());
            collisionDetector.Receive(_config);
            collisionDetector.OnDetect += (Entity entity) =>
            {
                if (entity.TryGetComponent(out Quadcopter quadcopter))
                    bypassDetector.Disactivate();
            };

            client.gameObject
                .AddComponent<Mover>()
                .Receive(_config);
            return client;
        }
    }
}
