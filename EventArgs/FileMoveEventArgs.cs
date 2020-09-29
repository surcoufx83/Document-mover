using System;
using System.IO;

namespace Document_mover
{
    public class FileMoveEventArgs : EventArgs
    {
        public FileInfo File { get; set; }
    }
}
