using UnityEngine;

namespace Assets.Scripts
{
    [CreateAssetMenu(menuName = "Config/Clothesline", fileName = "New Clothesline Config")]
    public class ClotheslineConfig : MultiplePrefabActorConfig<Clothesline>
    {
        [SerializeField] [Range(1, 10)] private float _moveSpeed;

        public float MoveSpeed { get => _moveSpeed; }
    }
}
