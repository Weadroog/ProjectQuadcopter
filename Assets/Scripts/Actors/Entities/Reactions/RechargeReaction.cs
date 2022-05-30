namespace Assets.Scripts
{
    class RechargeReaction : Reaction
    {
        private Charger _charger;

        public RechargeReaction(Quadcopter quadcopter)
        {
            _charger = quadcopter.GetComponent<Charger>();
        }

        public override void React()
        {
            _charger.ChargeUp();
        }
    }
}
