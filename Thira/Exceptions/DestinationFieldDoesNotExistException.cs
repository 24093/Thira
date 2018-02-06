using System;
using Alkl.Thira.DomainObjects;

namespace Alkl.Thira.Exceptions
{
    internal class DestinationFieldDoesNotExistException : InvalidMoveException
    {
        public DestinationFieldDoesNotExistException(Field from, Field to, string message = null, Exception innerException = null)
            : base(from, to, message, innerException)
        {
        }
    }
}