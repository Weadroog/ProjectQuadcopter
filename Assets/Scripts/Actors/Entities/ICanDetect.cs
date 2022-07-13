namespace Assets.Scripts
{
    public interface ICanDetect
    {
        public float XDetectionDistanceLeft { get; }
        public float XDetectionDistanceRight { get; }
        public float ZDetectionDistanceForward { get; }
        public float ZDetectionDistanceBackward { get; }
        public float YDetectionDistanceUp { get; }
        public float YDetectionDistanceDown { get; }
    }
}
