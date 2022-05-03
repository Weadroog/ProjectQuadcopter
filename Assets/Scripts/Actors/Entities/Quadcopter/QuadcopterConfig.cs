using UnityEngine;

namespace Assets.Scripts
{
    [CreateAssetMenu(menuName = "Config/Quadcopter", fileName = "New Quadcopter Config")]
    public class QuadcopterConfig : ActorConfig<Quadcopter> 
    {
        [SerializeField][Range(0, 1)] private float _motionDuration;
        [SerializeField] [Range(1, 5)] private int _HP;

        public int HP { get =>_HP; }
        public float MotionDuration => _motionDuration;
    }
}
