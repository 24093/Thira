using System;

namespace Alkl.Thira.Exceptions
{
    internal class FieldContainsBuilderException : BoardException
    {
        public FieldContainsBuilderException(string message = null, Exception innerException = null)
            : base(message, innerException)
        {
        }
    }
}