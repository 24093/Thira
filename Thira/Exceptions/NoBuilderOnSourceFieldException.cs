using System;
using Alkl.Thira.DomainObjects;

namespace Alkl.Thira.Exceptions
{
    public class NoBuilderOnSourceFieldException : InvalidMoveException
    {
        public NoBuilderOnSourceFieldException(Field from = null, Field to = null,
            string message = null, Exception innerException = null)
            : base(from, to, message, innerException)
        {
        }
    }
}