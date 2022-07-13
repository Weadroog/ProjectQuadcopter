using UnityEngine;
using General;
using Level;

namespace Entities
{
    public abstract class EntityFactory<E, C> : ActorFactory<E> where E : Entity where C : Config
    {
        protected C _config;

        public EntityFactory(C config) => _config = config;

        public EntityFactory(C config, Container container) : base(container) => _config = config;

        public EntityFactory(C config, Container container, Vector3 spawnPosition) : base(container, spawnPosition) => _config = config;
    }
}
