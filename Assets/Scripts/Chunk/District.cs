using System.Collections.Generic;

namespace Chunk
{
    public class District : PieceOfChunk 
    {
        private List<Window> _windows = new List<Window>();

        protected override void Awake()
        {
            base.Awake();
            _windows.AddRange(GetComponentsInChildren<Window>());
        }

        public IEnumerable<Window> GetWindows() => _windows;
    }
}