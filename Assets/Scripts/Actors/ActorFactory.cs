using UnityEngine;

namespace Assets.Scripts
{
    public abstract class ActorFactory<A> : IFactory<A> where A : Actor
    {
        
        protected Container _container;
        protected Vector3 _spawnPosition;

        public ActorFactory() { }

        public ActorFactory(Container container)
        {
            _container = container;
            _spawnPosition = container.transform.position;
        }

        public ActorFactory(Container container, Vector3 spawnPosition)
        {
            _container = container;
            _spawnPosition = spawnPosition;
        }

        public abstract A GetCreated();
    }
}
