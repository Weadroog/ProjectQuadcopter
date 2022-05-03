using UnityEngine;

namespace Assets.Scripts
{
    [CreateAssetMenu(menuName = "Config/Chunk", fileName = "New Chunk Config")]
    public class ChunkConfig : MultiplePrefabActorConfig<Chunk>
    {
        [SerializeField] [Range(1, 10)] private float _moveSpeed;

        public float MoveSpeed { get => _moveSpeed; }
    }
}
