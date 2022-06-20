namespace Assets.Scripts
{
    public class TakeDamageReaction : Reaction
    {
        private Lifer _lifer;
        private QuadcopterNextReaction _nextReaction;

        public TakeDamageReaction(Quadcopter quadcopter)
        {
            _lifer = quadcopter.GetComponent<Lifer>();
            _nextReaction = new QuadcopterNextReaction(quadcopter);
        }

        public override void React()
        {
            _lifer.TakeDamage();
            _nextReaction.React();
        }
    }
}
