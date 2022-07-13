using General;
using Entities;
using Reactions;

namespace Components
{
    public class PizzaEquipper : ConfigReceiver<PizzaGuyConfig>
    {
        private PizzaPoint _pizzaPoint;
        private Pizza _equipedPizza;
        private Pizza _pizza;

        public Pizza EquipedPizza
        {
            get => _equipedPizza;

            private set
            {
                _equipedPizza?.gameObject.SetActive(false);
                value.gameObject.SetActive(true);
                _equipedPizza = value;
            }
        }

        public override void Receive(PizzaGuyConfig config)
        {
            base.Receive(config);
            _pizzaPoint = GetComponentInChildren<PizzaPoint>();

            Pizza pizza = Instantiate(_config.PizzaPrefab, _pizzaPoint.transform);
            pizza.AddReaction<CollisionDetector, Quadcopter>(new GrabPizzaReaction(pizza));
            _pizza = pizza;
            Equip();
        }

        public void Equip() => EquipedPizza = _pizza;
    }
}

