using UnityEngine;

namespace Assets.Scripts
{
    class ClotheslineFactory : ActorFactory<Clothesline, ClotheslineConfig>
    {
        public ClotheslineFactory(ClotheslineConfig config) : base(config) { }

        public override Clothesline GetCreated()
        {
            Clothesline clothesline = Object.Instantiate(_config.Prefab);
            clothesline.gameObject.AddComponent<Mover>();
            clothesline.gameObject.AddComponent<Disappearer>();
            return clothesline;
        }
    }
}
