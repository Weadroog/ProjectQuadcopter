using UnityEngine;

namespace Assets.Scripts
{
    [CreateAssetMenu(menuName = "Config/Quadcopter", fileName = "New Quadcopter Config")]
    public class QuadcopterConfig : Config
    {
        [SerializeField] private Quadcopter _prefab;
        [SerializeField] [Range(0, 1)] private float _motionDuration;
        [SerializeField] [Range(1, 5)] private int _lives;
        [SerializeField] [Range(1, 5)] private int _charge;
        [SerializeField] [Range(1, 15)] private int _chargeDecreaseTime;
        [SerializeField] [Range(0, 1000)] private int _money;

        public Quadcopter Prefab => _prefab;
        public int MaxLives => _lives;
        public int ChargeLimit => _charge;
        public int ChargeDecreaseTime => _chargeDecreaseTime;
        public float MotionDuration => _motionDuration;
        public int Money => _money;

    }
}
