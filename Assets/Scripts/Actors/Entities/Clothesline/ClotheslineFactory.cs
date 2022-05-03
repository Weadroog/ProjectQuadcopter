using UnityEngine;

namespace Assets.Scripts
{
    class ClotheslineFactory : ActorFactory<Clothesline, ClotheslineConfig>
    {
        private Quadcopter _quadcopter;

        public ClotheslineFactory(ClotheslineConfig config, Quadcopter quadcopter) : base(config) => _quadcopter = quadcopter;

        public override Clothesline GetCreated()
        {
            Clothesline clothesline = Object.Instantiate(_config.Prefab);
            clothesline.gameObject.AddComponent<Mover>().SetSelfSpeed(_config.MoveSpeed);
            clothesline.gameObject.AddComponent<Disappearer>();
            clothesline.AddReaction<CollisionDetector>(new KnockedDownReaction(_quadcopter));
            return clothesline;
        }
    }
}
