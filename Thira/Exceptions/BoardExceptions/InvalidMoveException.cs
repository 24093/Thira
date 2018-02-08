using System;

namespace Alkl.Thira.Exceptions.BoardExceptions
{
    public class InvalidMoveException : BoardException
    {
        public InvalidMoveException(string message = null, Exception innerException = null)
            : base(message, innerException)
        {
        }
    }
}