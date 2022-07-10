using UnityEngine;

namespace Assets.Scripts
{
    [CreateAssetMenu(menuName = "Config/Aggressive Bird", fileName = "New Aggressive Bird Config")]
    public class AggressiveBirdConfig : Config, ICanMove, ICanDetect
    {
        [SerializeField] private AggressiveBird[] _prefabs;
        [SerializeField][Range(1, 100)] private float _selfSpeed;
        [SerializeField][Range(1, 100)] private float _detectionDistance;

        public AggressiveBird Prefab => _prefabGetter.Get(_prefabs);
        public float SelfSpeed => _selfSpeed;
        public float DetectionDistance => _detectionDistance;
        public float DetectionWidth => 0;
    }
}
