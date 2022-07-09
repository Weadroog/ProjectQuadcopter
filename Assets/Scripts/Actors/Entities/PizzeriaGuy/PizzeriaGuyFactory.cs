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

            pizzeriaGuy.gameObject
               .AddComponent<Disappearer>()
               .SetDisappearPoint(_wayMatrix.DisappearPoint);

            BoxCollider pizzeriaGuyCollider = pizzeriaGuy.GetComponent<BoxCollider>();
            pizzeriaGuyCollider.size = new Vector3(WayMatrix.HorizontalSpacing * 2, WayMatrix.VerticalSpacing * 2, _config.DetectZoneLength);

            pizzeriaGuy.gameObject
                .AddComponent<PizzaEquipper>()
                .Receive(_config);

            CollisionDetector collisionDetector = pizzeriaGuy.AddReaction<CollisionDetector, Quadcopter>(new GrabPizzaReaction());
            collisionDetector.Receive(_config);
            collisionDetector.OnDetect += (Entity entity) =>
            {
                //if (entity.TryGetComponent(out Quadcopter quadcopter))
                    //bypassDetector.Disactivate();
            };

            pizzeriaGuy.gameObject
                .AddComponent<Mover>()
                .Receive(_config);

            return pizzeriaGuy;
        }
    }
}
 