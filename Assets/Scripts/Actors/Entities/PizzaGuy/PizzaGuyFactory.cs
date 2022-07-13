using UnityEngine;

namespace Assets.Scripts
{
    public class PizzaGuyFactory : EntityFactory<PizzaGuy, PizzaGuyConfig>
    {
        private readonly WayMatrix _wayMatrix = new();

        public PizzaGuyFactory(PizzaGuyConfig config) : base(config) { }

        public override PizzaGuy GetCreated()
        {
            PizzaGuy pizzaGuy = Object.Instantiate(_config.Prefab);

            Disappearer disappearer = pizzaGuy.gameObject
               .AddComponent<Disappearer>()
               .SetDisappearPoint(_wayMatrix.DisappearPoint);

            disappearer.OnDisappear += () => Deliverer.OnDeliverySequenceFailed?.Invoke();
            Deliverer.OnPizzaGrabbed += () => pizzaGuy.gameObject.SetActive(false);

            PizzaEquipper pizzaEquipper = pizzaGuy.gameObject.AddComponent<PizzaEquipper>();
            pizzaEquipper.Receive(_config);

            BoxDetector boxDetector = pizzaGuy
                .AddReaction<BoxDetector, Quadcopter>(new PizzaThrowingReaction(pizzaEquipper.EquipedPizza));

            boxDetector.Receive(_config);

            pizzaGuy.gameObject
                .AddComponent<Mover>()
                .Receive(_config);

            return pizzaGuy;
        }
    }
}
 