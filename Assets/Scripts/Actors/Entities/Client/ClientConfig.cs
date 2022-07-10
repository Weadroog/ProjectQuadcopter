using UnityEngine;

namespace Assets.Scripts
{
    [CreateAssetMenu(menuName = "Config/Client", fileName = "New Client Config")]
    public class ClientConfig : Config, ICanDetect, ICanMove
    {
        [SerializeField] private Client[] _prefabs;
        [SerializeField][Range(1, 30)] private int _bypassDistance;

        public Client Prefab => _prefabGetter.Get(_prefabs);
        public float DetectionDistance => _bypassDistance;
        public float DetectionWidth => 0;
        public float SelfSpeed => 0;

    }
}
