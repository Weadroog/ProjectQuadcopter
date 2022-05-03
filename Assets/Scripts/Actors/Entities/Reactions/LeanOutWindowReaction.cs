namespace Assets.Scripts
{
    public class LeanOutWindowReaction : IReaction
    {
        private WindowLeanOuter _windowLeanOuter;

        public LeanOutWindowReaction(WindowLeanOuter windowLeanOuter) => _windowLeanOuter = windowLeanOuter;

        public void React() => _windowLeanOuter.LeanOutWindow();
    }
}
