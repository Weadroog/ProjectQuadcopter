using UnityEngine;

namespace Assets.Scripts
{
    public abstract class ReactableEntity : Entity
    {
        public D AddReaction<D>(IReaction reaction) where D : Component
        {
            IDetector detector = gameObject.AddComponent<D>() as IDetector;
            detector.OnDetect += reaction.React;
            return detector as D;
        }
    }
}
