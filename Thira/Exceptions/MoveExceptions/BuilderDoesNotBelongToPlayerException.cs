using System;
using Alkl.Thira.DomainObjects;

namespace Alkl.Thira.Exceptions.MoveExceptions
{
    internal class BuilderDoesNotBelongToPlayerException : MoveException
    {
        public BuilderDoesNotBelongToPlayerException(Field from, Field to, string message = null,
            Exception innerException = null)
            : base(from, to, message, innerException)
        {
        }
    }
}