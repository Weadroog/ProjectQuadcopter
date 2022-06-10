using UnityEngine;

namespace Assets.Scripts
{
    public class MultiplePrefabActorConfig<A> : Config where A : Actor
    {
        [SerializeField] protected A[] _prefabs;

        private int _prefabIndex;

        public A Prefab
        {
            get
            {
                _prefabIndex = (_prefabIndex == _prefabs.Length) ? 0 : _prefabIndex;
                A prefab = _prefabs[_prefabIndex];
                _prefabIndex++;
                return prefab;
            }
        }

        public int PrefabsCount => _prefabs.Length;
    }
}
