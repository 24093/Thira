using System;
using Alkl.Thira.DomainObjects;

namespace Alkl.Thira.Exceptions.BuildExceptions
{
    internal class NoBuilderOnBuilderFieldException : BuildException
    {
        public NoBuilderOnBuilderFieldException(Field builderField, Field targetField, string message = null,
            Exception innerException = null)
            : base(builderField, targetField, message, innerException)
        {
        }
    }
}