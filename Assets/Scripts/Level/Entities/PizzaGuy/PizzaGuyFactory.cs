using UnityEngine;
using Components;
using Reactions;

namespace Entities
{
    public class PizzaGuyFactory : EntityFactory<PizzaGuy, PizzaGuyConfig>
    {
        public PizzaGuyFactory(PizzaGuyConfig config) : base(config) { }

        public override PizzaGuy GetCreated()
        {
            PizzaGuy pizzaGuy = Object.Instantiate(_config.Prefab);

            pizzaGuy.gameObject.AddComponent<Disappearer>().OnDisappear += () => Deliverer.OnDeliverySequenceFailed?.Invoke();

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
 