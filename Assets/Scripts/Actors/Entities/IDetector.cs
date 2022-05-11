using System;

namespace Assets.Scripts
{
    public interface IDetector
    {
        public event Action<Entity> OnDetect;
        public event Action OnDetectAll;
    }
}
