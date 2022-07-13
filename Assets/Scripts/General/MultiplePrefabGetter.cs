using System.Collections.Generic;
using System.Linq;

namespace General
{
    public struct MultiplePrefabGetter
    {
        private int _currentPrefabIndex;

        public T Get<T>(IEnumerable<T> prefabs)
        {
            List<T> tempPrefabs = prefabs.ToList();
            _currentPrefabIndex = (_currentPrefabIndex >= tempPrefabs.Count()) ? 0 : _currentPrefabIndex;
            T prefab = tempPrefabs[_currentPrefabIndex];
            _currentPrefabIndex++;
            return prefab;
        }
    }
}
