namespace Assets.Scripts
{
    public class TakeDamageReaction : Reaction
    {
        private Liver _lives;

        public TakeDamageReaction(Liver lives)
        {
            _lives = lives;
        }

        public override void React()
        {
            _lives.TakeDamage();
        }
    }
}
