
namespace Assets.Scripts
{
    public class FailedGrabPizzaReaction : Reaction
    {
        public override void React()
        {
            Deliverer.OnDeliverySequenceFailed?.Invoke();
        }

    }

}
