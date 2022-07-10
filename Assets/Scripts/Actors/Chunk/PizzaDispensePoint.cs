using UnityEngine;

namespace Assets.Scripts
{
    public class PizzaDispensePoint : MonoBehaviour
    {
        private void OnDrawGizmos()
        {
            Gizmos.color = Color.green;
            Gizmos.DrawSphere(transform.position, 1);
        }
    }
}
