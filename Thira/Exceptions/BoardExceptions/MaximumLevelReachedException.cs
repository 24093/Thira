using System;

namespace Alkl.Thira.Exceptions.BoardExceptions
{
    public class MaximumLevelReachedException : BoardException
    {
        public MaximumLevelReachedException(string message = null, Exception innerException = null)
            : base(message, innerException)
        {
        }
    }
}