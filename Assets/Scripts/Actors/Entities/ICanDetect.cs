namespace Assets.Scripts
{
    public interface ICanDetect
    {
        public float DetectionDistance { get; }
        public float DetectionWidth { get; }
        public int DetectFloorsUp { get; }
        public int DetectFloorsDown { get; }
    }
}
