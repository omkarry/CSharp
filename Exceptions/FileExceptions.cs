using System;

namespace FileHandling.Exceptions
{
    public class InvalidFileTypeException : Exception
    {
        public InvalidFileTypeException() { }

        public InvalidFileTypeException(string message) : base(message) { }
    }
}
