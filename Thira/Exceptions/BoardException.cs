using System;

namespace Alkl.Thira.Exceptions
{
    public abstract class BoardException<TError> : BoardException
    {
        public TError Error { get; private set; }

        protected BoardException(TError error, string message = null, Exception innerException = null)
            : base(message, innerException)
        {
            Error = error;
        }
    }

    public abstract class BoardException : InvalidOperationException
    {
        protected BoardException(string message = null, Exception innerException = null)
            : base(message, innerException)
        {
        }
    }
}