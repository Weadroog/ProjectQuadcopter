using UnityEngine;

namespace Assets.Scripts
{
    public class Window : MonoBehaviour
    {
        [SerializeField] private Material _opendMaterial;
        [SerializeField] private Material _closedMaterial;

        private MeshRenderer _meshrRenderer;
        private SpawnPoint _spawnPoint;

        public SpawnPoint SpawnPoint => _spawnPoint;

        private void Awake()
        {
            _meshrRenderer = GetComponentInChildren<MeshRenderer>();
            _spawnPoint = GetComponentInChildren<SpawnPoint>();
        }

        public void Close() => _meshrRenderer.material = _closedMaterial;

        public void Open() => _meshrRenderer.material = _opendMaterial;
    }
}