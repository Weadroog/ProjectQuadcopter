using UnityEngine;

namespace Assets.Scripts
{
    public abstract class ConfigReceiver<C> : MonoBehaviour
    {
        protected C _config;

        public void Receive(C config) => _config = config;
    }
}
