using Entities;

namespace Reactions
{
    public abstract class Reaction : IReaction 
    {
        protected Entity _detectableEntity;

        public void TryToReact<E>(Entity detectedEntity) where E : Entity
        {
            if (detectedEntity is E)
            {
                _detectableEntity = detectedEntity;
                React();
            }   
        }

        public abstract void React();
    }
}
