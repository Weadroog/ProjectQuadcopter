using UnityEngine;
using General;

namespace Entities
{
    [CreateAssetMenu(menuName = "Config/Client", fileName = "New Client Config")]
    public class ClientConfig : Config, ICanMove, ICanDetect
    {
        [SerializeField] private Client[] _prefabs;
        [SerializeField] [Range(1, 30)] private int _bypassDistance;

        public Client Prefab => _prefabGetter.Get(_prefabs);
        public float SelfSpeed => 0;

        public float XDetectionDistanceLeft => 0;

        public float XDetectionDistanceRight => 0;

        public float ZDetectionDistanceForward => 0;

        public float ZDetectionDistanceBackward => 0;

        public float YDetectionDistanceUp => 0;

        public float YDetectionDistanceDown => 0;
    }
}
