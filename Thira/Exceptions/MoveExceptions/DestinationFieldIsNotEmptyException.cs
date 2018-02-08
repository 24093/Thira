using System;
using Alkl.Thira.DomainObjects;

namespace Alkl.Thira.Exceptions.MoveExceptions
{
    internal class DestinationFieldIsNotEmptyException : MoveException
    {
        public DestinationFieldIsNotEmptyException(Field from, Field to, string message = null,
            Exception innerException = null)
            : base(from, to, message, innerException)
        {
        }
    }
}