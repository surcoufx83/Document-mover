using System;
using System.IO;

namespace Document_mover
{
    public class FileCopyEventArgs : EventArgs
    {
        public FileInfo File { get; set; }
    }
}
