using UnityEngine;

namespace Assets.Scripts
{
    [CreateAssetMenu(menuName = "Config/Client", fileName = "New Client Config")]
    public class ClientConfig : MultiplePrefabActorConfig<Client>, ICanDetect, ICanMove
    {
        [SerializeField][Range(1, 30)] private int _bypassOffset;

        public float DetectionDistance => _bypassOffset;
        public float SelfSpeed => 0;
    }
}
