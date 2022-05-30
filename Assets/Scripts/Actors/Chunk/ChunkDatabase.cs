using UnityEngine;

namespace Assets.Scripts
{
    [CreateAssetMenu(menuName = "ChunkDatabase", fileName = "New Chunk Database")]
    public class ChunkDatabase : MultiplePrefabActorConfig<Chunk>
    {
        [SerializeField] [Range(1, 10)] private float _moveSpeed;

        public float MoveSpeed { get => _moveSpeed; }
    }
}
