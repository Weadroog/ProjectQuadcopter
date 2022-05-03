using UnityEngine;

namespace Assets.Scripts
{
    public class SpawnPoint : MonoBehaviour
    {
        private void Awake()
        {
            if (transform.position.x > 0) transform.localScale = new Vector3(-1, 1, 1);
        }
    }
}