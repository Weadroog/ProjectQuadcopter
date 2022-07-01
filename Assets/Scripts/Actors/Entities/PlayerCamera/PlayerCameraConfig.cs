using UnityEngine;

namespace Assets.Scripts
{
    [CreateAssetMenu(menuName = "Config/PlayerCamera", fileName = "New PlayerCamera Config")]
    public class PlayerCameraConfig : Config 
    {
        [SerializeField] private PlayerCamera _prefab;

        public PlayerCamera Prefab => _prefab;
    }
}
