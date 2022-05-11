using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    public class Chunk : Actor 
    {
        private List<Window> _windows = new List<Window>();

        public float Size { get; private set; }
        public Vector3 ConnectPosition => new Vector3(transform.position.x, transform.position.y, transform.position.z + Size);

        private void Awake()
        {
            Size = GetComponentInChildren<MeshRenderer>().bounds.size.z;
            _windows.AddRange(GetComponentsInChildren<Window>());
        }

        public void SettleWindows(Pool<NetGuy> netGuyPool, int density)
        {
            foreach (Window window in _windows)
            {
                if (Random.Range(0, 100) > density)
                {
                    window.Close();
                    continue;
                }

                netGuyPool.Get(window.transform.position);
                window.Open();
            }
        }
    }
}