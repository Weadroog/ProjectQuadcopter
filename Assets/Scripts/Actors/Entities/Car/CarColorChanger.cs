using UnityEngine;

namespace Assets.Scripts
{ 
    public class CarColorChanger : MonoBehaviour
    {
        [SerializeField] private MeshRenderer _meshRenderer;

        private void Awake() =>_meshRenderer = GetComponentInChildren<MeshRenderer>();
        
        public void ChangeColorRandom()
        {
            Material material = new Material(Shader.Find("Standard"));
            material.color = Random.ColorHSV();
            _meshRenderer.material = material;
        }
    }
}