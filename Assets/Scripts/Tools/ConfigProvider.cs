using System.Linq;
using UnityEngine;

namespace Assets.Scripts
{
    public class ConfigProvider<C> : MonoBehaviour where C : Config
    {
        private C _config;

        private void Awake() => GetComponents<ConfigReceiver<C>>().ToList().ForEach(configReceiver => configReceiver.Receive(_config));
    }
}
