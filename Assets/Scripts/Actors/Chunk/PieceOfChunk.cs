using UnityEngine;

namespace Assets.Scripts
{
    public class PieceOfChunk : Actor
    {
        public Vector3 Size { get; private set; }

        protected virtual void Awake() => Size = GetComponentInChildren<MeshRenderer>().bounds.size;
    }
}