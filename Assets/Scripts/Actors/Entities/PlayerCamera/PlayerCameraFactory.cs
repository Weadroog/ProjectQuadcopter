using UnityEngine;

namespace Assets.Scripts
{
    class PlayerCameraFactory : EntityFactory<PlayerCamera, PlayerCameraConfig>
    {
        public PlayerCameraFactory(PlayerCameraConfig config, Container container, Vector2 position) : base(config, container, position) { }

        public override PlayerCamera GetCreated()
        {
            return Object.Instantiate(_config.Prefab, _spawnPosition, Quaternion.identity, _container.transform);
        }
    }
}
