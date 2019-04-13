using System;

namespace DocumentsKeeperDemo.Core.Extensions
{
    public class FolderNameIsNotSpecifiedException : Exception
    {
        public FolderNameIsNotSpecifiedException(): base() { }
        public FolderNameIsNotSpecifiedException(string message): base(message) { }
    }
}
