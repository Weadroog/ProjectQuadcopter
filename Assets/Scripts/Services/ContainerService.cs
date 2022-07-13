using UnityEngine;
using General;

namespace Services
{
    public class ContainerService : MonoBehaviour
    {
        public static Container GetCreatedContainer(string title, Transform parent)
        {
            GameObject container = new GameObject(title);
            container.transform.SetParent(parent);
            container.transform.position = Vector3.zero;
            return container.AddComponent<Container>();
        }

        public static Container GetCreatedContainer(string title, Transform parent, Vector3 position)
        {
            GameObject container = new GameObject(title);
            container.transform.SetParent(parent);
            container.transform.position = position;
            return container.AddComponent<Container>();
        }
    }
}