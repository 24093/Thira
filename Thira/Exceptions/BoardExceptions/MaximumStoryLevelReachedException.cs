using System;

namespace Alkl.Thira.Exceptions.BoardExceptions
{
    public class MaximumStoryLevelReachedException : BoardException
    {
        public MaximumStoryLevelReachedException(string message = null, Exception innerException = null)
            : base(message, innerException)
        {
        }
    }
}