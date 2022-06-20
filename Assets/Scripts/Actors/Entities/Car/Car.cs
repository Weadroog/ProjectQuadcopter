using UnityEditor;

namespace Assets.Scripts
{
    public class Car : Entity
    {
        public CarColorChanger CarColorChanger { get; private set; }

        private void Awake() => CarColorChanger = GetComponent<CarColorChanger>();
    }
}