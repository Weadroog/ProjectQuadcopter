using UnityEngine;
using UnityEngine.Serialization;

namespace Assets.Scripts
{
    [CreateAssetMenu(menuName = "Config/Aggressive Bird", fileName = "New Aggressive Bird Config")]
    public class AggressiveBirdConfig : MultiplePrefabActorConfig<AggressiveBird>
    {
       [SerializeField] [Range(1, 10)] private float _moveSpeed;
       [SerializeField] [Range(1, 10)] private float _visibilDetector;

       public float MoveSpeed { get => _moveSpeed; }
       public float VisibilDetector { get => _visibilDetector; }
    }
}
