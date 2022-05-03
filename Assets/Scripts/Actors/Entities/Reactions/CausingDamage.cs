namespace Assets.Scripts
{
    public class CausingDamage : IReaction
    {
        private Health _health;

        public CausingDamage(Quadcopter quadcopter) => _health = quadcopter.gameObject.GetComponent<Health>();

        public void React() => _health.TakeDamage();
    }
}