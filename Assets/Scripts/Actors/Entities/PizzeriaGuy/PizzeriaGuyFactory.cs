using UnityEngine;

namespace Assets.Scripts
{
    public class PizzeriaGuyFactory : EntityFactory<PizzeriaGuy, PizzeriaGuyConfig>
    {
        private WayMatrix _wayMatrix = new();

        public PizzeriaGuyFactory(PizzeriaGuyConfig config) : base(config) { }

        public override PizzeriaGuy GetCreated()
        {
            PizzeriaGuy pizzeriaGuy = Object.Instantiate(_config.Prefab);

            Disappearer disappearer = pizzeriaGuy.gameObject
               .AddComponent<Disappearer>()
               .SetDisappearPoint(_wayMatrix.DisappearPoint);

            disappearer.OnDisappear += () => Deliverer.OnDeliverySequenceFailed?.Invoke();
            Deliverer.OnPizzaGrabbed += () => pizzeriaGuy.gameObject.SetActive(false);

            BoxCollider pizzeriaGuyCollider = pizzeriaGuy.GetComponent<BoxCollider>();
            pizzeriaGuyCollider.size = new Vector3(WayMatrix.HorizontalSpacing * 2, WayMatrix.VerticalSpacing * 2, _config.DetectZoneLength);

            PizzaEquipper pizzaEquipper = pizzeriaGuy.gameObject.AddComponent<PizzaEquipper>();
            pizzaEquipper.Receive(_config);

            CollisionDetector collisionDetector = pizzeriaGuy
                .AddReaction<CollisionDetector, Quadcopter>(new PizzaThrowingReaction(pizzaEquipper.EquipedPizza));

            collisionDetector.Receive(_config);

            pizzeriaGuy.gameObject
                .AddComponent<Mover>()
                .Receive(_config);

            return pizzeriaGuy;
        }
    }
}
 