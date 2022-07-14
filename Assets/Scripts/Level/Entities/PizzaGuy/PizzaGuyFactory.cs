using UnityEngine;
using Components;
using Reactions;

namespace Entities
{
    public class PizzaGuyFactory : EntityFactory<PizzaGuy, PizzaGuyConfig>
    {
        private Deliverer _deliverer;

        public PizzaGuyFactory(PizzaGuyConfig config, Deliverer deliverer) : base(config)
        {
            _deliverer = deliverer;
        }

        public override PizzaGuy GetCreated()
        {
            PizzaGuy pizzaGuy = Object.Instantiate(_config.Prefab);

            pizzaGuy.gameObject.AddComponent<Disappearer>().OnDisappear += () => _deliverer.DropPizza();

            _deliverer.OnPizzaGrabbed += () => pizzaGuy.gameObject.SetActive(false);

            PizzaEquipper pizzaEquipper = pizzaGuy.gameObject.AddComponent<PizzaEquipper>();
            pizzaEquipper.Deliverer = _deliverer;
            pizzaEquipper.Receive(_config);

            BoxDetector boxDetector = pizzaGuy
                .AddReaction<BoxDetector, Quadcopter>(new GrabPizzaReaction(pizzaEquipper.EquipedPizza, _deliverer));//new PizzaThrowingReaction(pizzaEquipper.EquipedPizza));

            boxDetector.Receive(_config);

            pizzaGuy.gameObject
                .AddComponent<Mover>()
                .Receive(_config);

            return pizzaGuy;
        }
    }
}
 