using System;

namespace Assets.Scripts
{
    class Purse : ConfigReceiver<QuadcopterConfig>
    {
        public event Action<int> OnChanged;

        private int _money;

        public int Money
        {
            get => _money;

            private set
            {
                _money = value;

                OnChanged?.Invoke(_money);
            }
        }

        public void AddMoney(int money) => Money += money;

        public void SubtractMoney(int money) => Money -= money;

        public void SetInitialAmount() => Money = _config.Money;
    }
}
