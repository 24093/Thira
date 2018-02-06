using System;
using Alkl.Thira.DomainObjects;

namespace Alkl.Thira.Exceptions
{
    public class DestinationFieldDoesNotExistException : InvalidMoveException
    {
        public DestinationFieldDoesNotExistException(Field from = null, Field to = null,
            string message = null, Exception innerException = null)
            : base(from, to, message, innerException)
        {
        }
    }
}