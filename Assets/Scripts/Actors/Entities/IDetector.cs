using System;

namespace Assets.Scripts
{
    public interface IDetector
    {
        public event Action OnDetect;
    }
}
