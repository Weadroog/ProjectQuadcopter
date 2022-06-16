namespace Assets.Scripts
{
    class RechargeReaction : Reaction
    {
        private Charger _charger;

        public RechargeReaction(Charger charger) => _charger = charger;

        public override void React() => _charger.Recharge();
    }
}
