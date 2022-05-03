using UnityEngine;

namespace Assets.Scripts
{
    public class ActorConfig<T> : Config where T : Actor
    {
        [SerializeField] protected T _prefab;

        public T Prefab => _prefab;
    }
}
