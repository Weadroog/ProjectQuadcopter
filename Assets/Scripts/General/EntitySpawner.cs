using UnityEngine;

namespace Assets.Scripts
{
    public class EntitySpawner : MonoBehaviour
    {
        private WayMatrix _wayMatrix = new WayMatrix();

        [Header("Configurations")]
        [SerializeField] private QuadcopterConfig _quadcopterConfig;
        [SerializeField] private PlayerCameraConfig _playerCameraConfig;
        [SerializeField] private AggressiveBirdConfig _aggressiveBurdConfig;
        [SerializeField] private CarConfig _carConfig;
        [SerializeField] private ClotheslineConfig _clotheslineConfig;
        [SerializeField] private NetGuyConfig _netGuyConfig;

        [Header("SpawnDensity")]
        [SerializeField][Range(0, 100)] private int _aggressiveBirdDensity;
        [SerializeField][Range(0, 100)] private int _carDensity;
        [SerializeField][Range(0, 100)] private int _clothesLineDensity;
        [SerializeField][Range(0, 100)] private int _netGuyDensity;

        public int AggressiveBirdDencity => _aggressiveBirdDensity;
        public int CarDensity => _carDensity;
        public int ClotheslineDensity => _clothesLineDensity;
        public int NetGuyDensity => _netGuyDensity;

        public Container EntitieContainer { get; private set; }
        public Pool<AggressiveBird> AggressiveBirdPool { get; private set; }
        public Pool<Car> CarPool { get; private set; }
        public Pool<Clothesline> ClotheslinePool { get; private set; }
        public Pool<NetGuy> NetGuyPool { get; private set; }

        public void Init(City city)
        {
            EntitieContainer = ContainerService.GetCreatedContainer("Entities", city.transform, Vector3.zero);
            Quadcopter quadcopter = GetCreatedEntity(new QuadcopterFactory(_quadcopterConfig, EntitieContainer));
            GetCreatedEntity(new PlayerCameraFactory(_playerCameraConfig, EntitieContainer, _wayMatrix.GetPosition(MatrixPosition.Center)));
            AggressiveBirdPool = new Pool<AggressiveBird>(new AggressiveBirdFactory(_aggressiveBurdConfig, quadcopter), EntitieContainer, 10);
            CarPool = new Pool<Car>(new CarFactory(_carConfig, quadcopter), EntitieContainer, 10);
            ClotheslinePool = new Pool<Clothesline>(new ClotheslineFactory(_clotheslineConfig, quadcopter), EntitieContainer, 10);
            NetGuyPool = new Pool<NetGuy>(new NetGuyFactory(_netGuyConfig, quadcopter), EntitieContainer, 10);
        }

        private E GetCreatedEntity<E>(IFactory<E> entityFactory) where E : Entity => entityFactory.GetCreated();
    }
}
