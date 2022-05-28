using UnityEngine;

namespace Assets.Scripts
{
    public class Window : MonoBehaviour
    {
        [SerializeField] private Material _opendMaterial;
        [SerializeField] private Material _closedMaterial;
        private MeshRenderer _meshrRenderer;
        private NetGuy _netGuy;

        private void Awake() => _meshrRenderer = GetComponentInChildren<MeshRenderer>();

        public bool IsEmpty => _netGuy == null;

        public void Settle(NetGuy netGuy) => _netGuy = netGuy;

        public void Close() => _meshrRenderer.material = _closedMaterial;

        public void Open() => _meshrRenderer.material = _opendMaterial;
    }
}