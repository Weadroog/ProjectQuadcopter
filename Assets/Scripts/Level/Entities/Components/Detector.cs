using System;
using General;
using Entities;

namespace Components
{
    public abstract class Detector : ConfigReceiver<ICanDetect>
    {
        public abstract event Action<Entity> OnDetect;
        public abstract event Action OnDetectAll;
    }
}
