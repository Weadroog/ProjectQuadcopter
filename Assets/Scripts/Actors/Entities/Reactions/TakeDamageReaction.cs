namespace Assets.Scripts
{
    public class TakeDamageReaction : Reaction
    {
        private Lifer _lifer;

        public TakeDamageReaction(Lifer lifer) => _lifer = lifer;

        public override void React() => _lifer.TakeDamage();
    }
}
