using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    public class Window : MonoBehaviour
    {
        [SerializeField] private Mesh _opendMesh;
        [SerializeField] private Mesh _closedMesh;
        [SerializeField][Range(0, 5)] private float _offset;
        private MeshFilter _meshFilter;

        private void Awake() => _meshFilter = GetComponentInChildren<MeshFilter>();

        public Vector3 GetSpawnPoint()
        {
            return transform.forward * -_offset + transform.position;
        }

        public void Close() => _meshFilter.mesh = _closedMesh;

        public void Open() => _meshFilter.mesh = _opendMesh;

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.green;
            Gizmos.DrawSphere(transform.forward * -_offset + transform.position, 1);
        }
    }
}
