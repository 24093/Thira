using System;
using Alkl.Thira.DomainObjects;

namespace Alkl.Thira.Exceptions
{
    internal class NoBuilderOnSourceFieldException : InvalidMoveException
    {
        public NoBuilderOnSourceFieldException(Field from, Field to, string message = null, Exception innerException = null)
            : base(from, to, message, innerException)
        {
        }
    }
}