using UnityEngine;

namespace Assets.Scripts
{
    [CreateAssetMenu(menuName = "Config/Aggressive Bird", fileName = "New Aggressive Bird Config")]
    public class AggressiveBirdConfig : MultiplePrefabActorConfig<AggressiveBird>, ICanMove, ICanDetect
    {
       [SerializeField] [Range(1, 100)] private float _selfSpeed;
       [SerializeField] [Range(1, 100)] private float _detectionDistance;

       public float SelfSpeed { get => _selfSpeed; }
       public float DetectionDistance { get => _detectionDistance; }
    }
}
