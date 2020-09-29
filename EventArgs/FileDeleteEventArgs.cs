using System;
using System.IO;

namespace Document_mover
{
    public class FileDeleteEventArgs : EventArgs
    {
        public FileInfo File { get; set; }
    }
}
