using System;

namespace Assets.Scripts
{
    public abstract class Detector : ConfigReceiver<ICanDetect>
    {
        public abstract event Action<Entity> OnDetect;
        public abstract event Action OnDetectAll;
    }
}
