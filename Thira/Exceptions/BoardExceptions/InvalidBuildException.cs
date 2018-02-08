using System;

namespace Alkl.Thira.Exceptions.BoardExceptions
{
    public class InvalidBuildException : BoardException
    {
        public InvalidBuildException(string message = null, Exception innerException = null)
            : base(message, innerException)
        {
        }
    }
}