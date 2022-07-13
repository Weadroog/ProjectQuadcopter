using UnityEngine;

namespace Level
{
    public class SpawnPoint : MonoBehaviour 
    {
        private void OnDrawGizmos()
        {
            float sphereRadius = 1;
            Gizmos.color = Color.green;
            Gizmos.DrawSphere(transform.position, sphereRadius);
        }
    }
}