namespace Assets.Scripts
{
    class PushForwardReaction : Reaction
    {
        private Mover _mover;

        public PushForwardReaction(Mover mover)
        {
            _mover = mover;
        }

        public override void React() 
        {
            _mover.SetSelfSpeed(_detectableEntity.GetComponent<Mover>().SelfSpeed);
        }
    }
}
