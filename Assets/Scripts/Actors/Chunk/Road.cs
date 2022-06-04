using UnityEngine;

namespace Assets.Scripts
{
    public class Road : PieceOfChunk 
    {
        public Vector3 LeftConnectPosition => new Vector3(transform.position.x - Size.x / 2, transform.position.y, transform.position.z);
        public Vector3 CentralConnectPosition => new Vector3(transform.position.x, transform.position.y, transform.position.z + Size.z);
        public Vector3 RightConnectPosition => new Vector3(transform.position.x + Size.x / 2, transform.position.y, transform.position.z);
    }
}