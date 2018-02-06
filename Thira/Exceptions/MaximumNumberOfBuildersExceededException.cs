using System;

namespace Alkl.Thira.Exceptions
{
    internal class MaximumNumberOfBuildersExceededException : BoardException
    {
        public MaximumNumberOfBuildersExceededException(string message = null, Exception innerException = null)
            : base(message, innerException)
        {
        }
    }
}