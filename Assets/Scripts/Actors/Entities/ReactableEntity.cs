using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    public abstract class ReactableEntity : Entity
    {
        private Dictionary<Type, IDetector> _detectors = new Dictionary<Type, IDetector>();

        public D AddReaction<D, E>(Reaction reaction) where D : Component where E : Entity
        {
            if (_detectors.ContainsKey(typeof(D)) == false)
                _detectors.Add(typeof(D), gameObject.AddComponent<D>() as IDetector);

            _detectors[typeof(D)].OnDetect += reaction.TryToReact<E>;
            return _detectors[typeof(D)] as D;
        }

        public D AddReaction<D>(Reaction reaction) where D : Component
        {
            _detectors.Add(typeof(D), gameObject.AddComponent<D>() as IDetector);
            _detectors[typeof(D)].OnDetectAll += reaction.React;
            return _detectors[typeof(D)] as D;
        }
    }
}
