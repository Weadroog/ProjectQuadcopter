using UnityEngine;

namespace Assets.Scripts
{
    [CreateAssetMenu(menuName = "Config/Net", fileName = "New Net Config")]
    public class NetGuyConfig : MultiplePrefabActorConfig<NetGuy>
    {
        [SerializeField][Range(1, 100)] private float _detectionRange;

        public float DetectionRadius => _detectionRange;
        
    }
}
