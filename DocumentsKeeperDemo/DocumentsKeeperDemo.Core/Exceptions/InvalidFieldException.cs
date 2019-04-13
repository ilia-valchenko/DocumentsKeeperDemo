using System;

namespace DocumentsKeeperDemo.Core.Exceptions
{
    public class InvalidFieldException : Exception
    {
        public InvalidFieldException(): base() { }
        public InvalidFieldException(string message): base() { }
    }
}
