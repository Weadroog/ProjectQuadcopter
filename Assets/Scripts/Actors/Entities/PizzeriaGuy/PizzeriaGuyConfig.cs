using UnityEngine;

namespace Assets.Scripts
{
    [CreateAssetMenu(menuName = "Config/PizzeriaGuy", fileName = "New Pizzeria Guy Config")]
    public class PizzeriaGuyConfig : Config, ICanDetect, ICanMove
    {
        [SerializeField] private PizzeriaGuy[] _prefabs;
        [SerializeField][Range(1,30)] private int _bypassOffset;

        public PizzeriaGuy Prefab => _prefabGetter.Get(_prefabs);
        public float DetectionDistance => _bypassOffset;
        public float SelfSpeed => 0;
    }
}

