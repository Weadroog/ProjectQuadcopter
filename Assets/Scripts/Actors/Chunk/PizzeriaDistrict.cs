namespace Assets.Scripts
{
    public class PizzeriaDistrict : PieceOfChunk
    {
        private PizzaDispensePoint _pizzaDispensePoint;

        public PizzaDispensePoint PizzaDispensePoint => _pizzaDispensePoint;

        protected override void Awake()
        {
            base.Awake();
            _pizzaDispensePoint = GetComponentInChildren<PizzaDispensePoint>();
        }
    }
}


