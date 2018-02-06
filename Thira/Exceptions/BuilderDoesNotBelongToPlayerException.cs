using System;
using Alkl.Thira.DomainObjects;

namespace Alkl.Thira.Exceptions
{
    internal class BuilderDoesNotBelongToPlayerException : InvalidMoveException
    {
        public BuilderDoesNotBelongToPlayerException(Field from, Field to, string message = null, Exception innerException = null)
            : base(from, to, message, innerException)
        {
        }
    }
}