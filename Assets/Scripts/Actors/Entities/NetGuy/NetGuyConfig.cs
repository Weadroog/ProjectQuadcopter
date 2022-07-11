using UnityEngine;
using NaughtyAttributes;

namespace Assets.Scripts
{
    [CreateAssetMenu(menuName = "Config/Net", fileName = "New Net Config")]
    public class NetGuyConfig : Config, ICanMove, ICanDetect
    {
        [SerializeField] private NetGuy[] _netGuyPrefabs;
        [SerializeField] private Net[] _netPrefabs;
        [SerializeField] [Range(1, 100)] private float _detectionDistanceX;
        [SerializeField] [Range(1, 100)] private float _detectionDistanceZ;
        [SerializeField] [Range(0, 10)] private float _shoveOutSpeed;
        [SerializeField] [Range(0, 10)] private float _shoveInSpeed;
        [SerializeField] [MinMaxSlider(-2, 2)] private Vector2Int _detectFloors;

        public NetGuy NetGuyPrefab => _prefabGetter.Get(_netGuyPrefabs);
        public Net NetPrefab => _prefabGetter.Get(_netPrefabs);
        public float SelfSpeed => 0;
        public float DetectionDistance => _detectionDistanceZ;
        public float DetectionWidth => _detectionDistanceX;
        public int DetectFloorsUp => _detectFloors.y;
        public int DetectFloorsDown => _detectFloors.x;
        public float ShoveOutSpeed => _shoveOutSpeed;
        public float ShoveInSpeed => _shoveInSpeed;
        public int NetPrefabsCount => _netPrefabs.Length;

    }
}
