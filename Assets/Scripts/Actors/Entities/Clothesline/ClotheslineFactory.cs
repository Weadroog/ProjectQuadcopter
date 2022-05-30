using UnityEngine;

namespace Assets.Scripts
{
    class ClotheslineFactory : EntityFactory<Clothesline, ClotheslineConfig>
    {
        private WayMatrix _wayMatrix = new();

        public ClotheslineFactory(ClotheslineConfig config) : base(config) { }

        public override Clothesline GetCreated()
        {
            Clothesline clothesline = Object.Instantiate(_config.Prefab);

            clothesline.gameObject
                .AddComponent<Mover>();

            clothesline.gameObject
                .AddComponent<Disappearer>()
                .SetDisappearPoint(_wayMatrix.DisappearPoint);

            return clothesline;
        }
    }
}
