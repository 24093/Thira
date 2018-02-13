using System;

namespace Alkl.Thira.Exceptions
{
    public class MaximumLevelReachedException : BoardException
    {
        public MaximumLevelReachedException(string message = null, Exception innerException = null)
            : base(message, innerException)
        {
        }
    }
}