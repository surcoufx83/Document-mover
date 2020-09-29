using Serilog;
using System;
using System.IO;

namespace Document_mover
{
    public class FileMover
    {

        public event EventHandler<FileCopyEventArgs> BeforeFileCopy;
        public event EventHandler<FileDeleteEventArgs> BeforeFileDelete;
        public event EventHandler<FileMoveEventArgs> BeforeFileMove;
        public event EventHandler<FileCopyEventArgs> FileCopied;
        public event EventHandler<FileDeleteEventArgs> FileDeleted;
        public event EventHandler<FileMoveEventArgs> FileMoved;
        public event EventHandler<FileCopyEventArgs> FileCopyFailed;
        public event EventHandler<FileDeleteEventArgs> FileDeleteFailed;
        public event EventHandler<FileMoveEventArgs> FileMoveFailed;

        public bool DeleteFile(FileInfo file, string trashFolder, string trashData)
        {
            Log.Information("Requested deleting {file}.", file.FullName);
            OnBeforeFileDelete(new FileDeleteEventArgs() { File = file });
            if (trashFolder != null && trashFolder != "" && trashData != null && trashData != "")
            {
                Log.Information("Trashbin active. File will be moved to trash.", file.FullName);
                FileInfo fileto = new FileInfo(Path.Combine(trashFolder, file.Name + "_" + Helper.UnixTimestamp.ToString()));
                if (MoveFile(file, fileto))
                {
                    File.AppendAllText(trashData, "DEL " + file.FullName + " => " + fileto.FullName + "\r\n");
                    OnFileDeleted(new FileDeleteEventArgs() { File = file });
                    return true;
                }
                OnFileDeleteFailed(new FileDeleteEventArgs() { File = file });
                return false;
            }
            try
            {
                file.Delete();
                OnFileDeleted(new FileDeleteEventArgs() { File = file });
                return true;
            } 
            catch(Exception ex) {
                Log.Fatal(ex, "Error deleting file {file}.", file.FullName);
                OnFileDeleteFailed(new FileDeleteEventArgs() { File = file });
                return false;
            }
        }

        public bool CopyFile(FileInfo from, DirectoryInfo to)
        {
            Log.Information("Requested copying {file} to folder {dest}.", from.FullName, to.FullName);
            FileInfo file = new FileInfo(Path.Combine(to.FullName, from.Name));
            return CopyFile(from, file);
        }

        public bool CopyFile(FileInfo from, FileInfo to)
        {
            Log.Information("Requested copying {file} to {dest}.", from.FullName, to.FullName);
            OnBeforeFileCopy(new FileCopyEventArgs() { File = from });
            try
            {
                File.Copy(from.FullName, to.FullName);
                OnFileCopied(new FileCopyEventArgs() { File = from });
                return true;
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "Error copying file {file} to {dest}.", from.FullName, to.FullName);
                OnFileCopyFailed(new FileCopyEventArgs() { File = from });
                return false;
            }
        }

        public bool MoveFile(FileInfo from, DirectoryInfo to)
        {
            Log.Information("Requested moving {file} to folder {dest}.", from.FullName, to.FullName);
            FileInfo file = new FileInfo(Path.Combine(to.FullName, from.Name));
            return MoveFile(from, file);
        }

        public bool MoveFile(FileInfo from, FileInfo to)
        {
            Log.Information("Requested moving {file} to {dest}.", from.FullName, to.FullName);
            OnBeforeFileMove(new FileMoveEventArgs() { File = from });
            try
            {
                File.Move(from.FullName, to.FullName);
                OnFileMoved(new FileMoveEventArgs() { File = from });
                return true;
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "Error moving file {file} to {dest}.", from.FullName, to.FullName);
                OnFileMoveFailed(new FileMoveEventArgs() { File = from });
                return false;
            }
        }

        protected virtual void OnBeforeFileCopy(FileCopyEventArgs e)
        {
            BeforeFileCopy?.Invoke(this, e);
        }

        protected virtual void OnBeforeFileDelete(FileDeleteEventArgs e)
        {
            BeforeFileDelete?.Invoke(this, e);
        }

        protected virtual void OnBeforeFileMove(FileMoveEventArgs e)
        {
            BeforeFileMove?.Invoke(this, e);
        }

        protected virtual void OnFileCopied(FileCopyEventArgs e)
        {
            FileCopied?.Invoke(this, e);
        }

        protected virtual void OnFileDeleted(FileDeleteEventArgs e)
        {
            FileDeleted?.Invoke(this, e);
        }

        protected virtual void OnFileMoved(FileMoveEventArgs e)
        {
            FileMoved?.Invoke(this, e);
        }

        protected virtual void OnFileCopyFailed(FileCopyEventArgs e)
        {
            FileCopyFailed?.Invoke(this, e);
        }

        protected virtual void OnFileDeleteFailed(FileDeleteEventArgs e)
        {
            FileDeleteFailed?.Invoke(this, e);
        }

        protected virtual void OnFileMoveFailed(FileMoveEventArgs e)
        {
            FileMoveFailed?.Invoke(this, e);
        }

    }
}
