using System;

namespace Alkl.Thira.Exceptions.BoardExceptions
{
    public class StoryNotAvailableException : BoardException
    {
        public StoryNotAvailableException(string message = null, Exception innerException = null)
            : base(message, innerException)
        {
        }
    }
}