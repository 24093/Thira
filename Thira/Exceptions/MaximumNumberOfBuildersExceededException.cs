using System;

namespace Alkl.Thira.Exceptions
{
    public class MaximumNumberOfBuildersExceededException : BoardException
    {
        public MaximumNumberOfBuildersExceededException(string message = null, Exception innerException = null)
            : base(message, innerException)
        {
        }
    }
}