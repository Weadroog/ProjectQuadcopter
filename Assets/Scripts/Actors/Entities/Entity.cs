using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    public abstract class Entity : Actor 
    {
        private Dictionary<Type, IDetector> _detectors = new Dictionary<Type, IDetector>();

        public D AddReaction<D>(Reaction reaction) where D : Component
        {
            if (_detectors.ContainsKey(typeof(D)) == false)
                _detectors.Add(typeof(D), gameObject.AddComponent<D>() as IDetector);

            _detectors[typeof(D)].OnDetectAll += reaction.React;
            return _detectors[typeof(D)] as D;
        }

        public D AddReaction<D, E>(Reaction reaction) where D : Component where E : Entity
        {
            if (_detectors.ContainsKey(typeof(D)) == false)
                _detectors.Add(typeof(D), gameObject.AddComponent<D>() as IDetector);

            _detectors[typeof(D)].OnDetect += reaction.TryToReact<E>;
            return _detectors[typeof(D)] as D;
        }

        public D AddReaction<D, E1, E2>(Reaction reaction) where D : Component where E1 : Entity where E2 : Entity
        {
            if (_detectors.ContainsKey(typeof(D)) == false)
                _detectors.Add(typeof(D), gameObject.AddComponent<D>() as IDetector);

            _detectors[typeof(D)].OnDetect += reaction.TryToReact<E1>;
            _detectors[typeof(D)].OnDetect += reaction.TryToReact<E2>;
            return _detectors[typeof(D)] as D;
        }

        public D AddReaction<D, E1, E2, E3>(Reaction reaction) where D : Component where E1 : Entity where E2 : Entity where E3 : Entity
        {
            if (_detectors.ContainsKey(typeof(D)) == false)
                _detectors.Add(typeof(D), gameObject.AddComponent<D>() as IDetector);

            _detectors[typeof(D)].OnDetect += reaction.TryToReact<E1>;
            _detectors[typeof(D)].OnDetect += reaction.TryToReact<E2>;
            _detectors[typeof(D)].OnDetect += reaction.TryToReact<E3>;
            return _detectors[typeof(D)] as D;
        }
    }
}