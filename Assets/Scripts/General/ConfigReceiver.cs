using UnityEngine;

namespace General
{
    public abstract class ConfigReceiver<C> : MonoBehaviour
    {
        protected C _config;

        public virtual void Receive(C config) => _config = config;
    }
}
