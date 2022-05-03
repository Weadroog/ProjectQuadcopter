using UnityEngine;

namespace Assets.Scripts
{
    public abstract class ActorFactory<A, C> : IFactory<A> where A : Actor where C : Config
    {
        protected C _config;
        protected Container _container;
        protected Vector3 _spawnPosition;

        public ActorFactory(C config) => _config = config;

        public ActorFactory(C config, Container container)
        {
            _config = config;
            _container = container;
            _spawnPosition = container.transform.position;
        }

        public ActorFactory(C config, Container container, Vector3 spawnPosition)
        {
            _config = config;
            _container = container;
            _spawnPosition = spawnPosition;
        }

        public abstract A GetCreated();
    }
}
