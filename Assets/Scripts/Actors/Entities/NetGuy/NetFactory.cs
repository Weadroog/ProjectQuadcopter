using UnityEngine;

namespace Assets.Scripts
{
    public class NetFactory : ActorFactory<Net>
    {
        private NetGuyConfig _config;
        private NetGuy _owner;

        public NetFactory(NetGuyConfig config, NetGuy owner)
        {
            _config = config;
            _owner = owner;
        }

        public override Net GetCreated()
        {
            return Object.Instantiate(_config.Net, _owner.transform);
        }
    }
}
