using System;

namespace Alkl.Thira.Exceptions
{
    public abstract class BoardException : Exception
    {
        protected BoardException(string message = null, Exception innerException = null)
            : base(message, innerException)
        {
        }
    }
}
