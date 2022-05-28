using UnityEngine;

namespace Assets.Scripts
{
    [CreateAssetMenu(menuName = "Config/Net", fileName = "New Net Config")]
    public class NetGuyConfig : MultiplePrefabActorConfig<NetGuy>
    {
        [SerializeField][Range(1, 100)] private float _detectionRadius;
        [SerializeField][Range(1, 10)] private float _semiMajorAxis;
        [SerializeField][Range(0, 10)] private float _leanOutingSpeed;

        public float DetectionRadius => _detectionRadius;
        public float SemiMajorAxis => _semiMajorAxis;
        public float LeanOutingSpeed => _leanOutingSpeed;
    }
}
