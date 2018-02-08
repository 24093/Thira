using System;
using Alkl.Thira.DomainObjects;

namespace Alkl.Thira.Exceptions.MoveExceptions
{
    internal abstract class MoveException : InvalidOperationException
    {
        public readonly Field FieldFrom;
        public readonly Field FieldTo;

        protected MoveException(Field from, Field to, string message = null, Exception innerException = null)
            : base(message, innerException)
        {
            FieldFrom = from;
            FieldTo = to;
        }
    }
}