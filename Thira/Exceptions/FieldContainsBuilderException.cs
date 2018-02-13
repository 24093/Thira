using System;

namespace Alkl.Thira.Exceptions
{
    public class FieldContainsBuilderException : BoardException
    {
        public FieldContainsBuilderException(string message = null, Exception innerException = null)
            : base(message, innerException)
        {
        }
    }
}