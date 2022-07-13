using Components;

namespace Reactions
{
    public class FailedGrabPizzaReaction : Reaction
    {
        public override void React()
        {
            Deliverer.OnDeliverySequenceFailed?.Invoke();
        }

    }

}
