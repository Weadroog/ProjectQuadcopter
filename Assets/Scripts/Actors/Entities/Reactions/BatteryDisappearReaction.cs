namespace Assets.Scripts
{
    class BatteryDisappearReaction : Reaction
    {
        private Battery _battery;

        public BatteryDisappearReaction(Battery battery) => _battery = battery;

        public override void React() => _battery.gameObject.SetActive(false);
    }
}
