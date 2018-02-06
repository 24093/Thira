using System;
using Alkl.Thira.DomainObjects;

namespace Alkl.Thira.Exceptions
{
    internal class SourceFieldDoesNotExistException : InvalidMoveException
    {
        public SourceFieldDoesNotExistException(Field from, Field to, string message = null, Exception innerException = null)
            : base(from, to, message, innerException)
        {
        }
    }
}