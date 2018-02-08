using System;

namespace Alkl.Thira.Exceptions.BoardExceptions
{
    public class LevelNotAvailableException : BoardException
    {
        public LevelNotAvailableException(string message = null, Exception innerException = null)
            : base(message, innerException)
        {
        }
    }
}