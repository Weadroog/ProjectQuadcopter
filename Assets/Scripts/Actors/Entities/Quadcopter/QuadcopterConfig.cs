using UnityEngine;

namespace Assets.Scripts
{
    [CreateAssetMenu(menuName = "Config/Quadcopter", fileName = "New Quadcopter Config")]
    public class QuadcopterConfig : ActorConfig<Quadcopter> 
    {
        [SerializeField] [Range(0, 1)] private float _motionDuration;
        [SerializeField] [Range(1, 5)] private int _lives;
        [SerializeField] [Range(1, 5)] private int _charge;
        [SerializeField] [Range(1, 15)] private int _chargeDecreaseTime;

        public int Lives => _lives;
        public int Charge => _charge;
        public int ChargeDecreaseTime => _chargeDecreaseTime;
        public float MotionDuration => _motionDuration;
    }
}
