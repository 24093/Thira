using System;
using Alkl.Thira.DomainObjects;

namespace Alkl.Thira.Exceptions.BuildExceptions
{
    internal class TargetFieldDoesNotExistException : BuildException
    {
        public TargetFieldDoesNotExistException(Field builderField, Field targetField, string message = null,
            Exception innerException = null)
            : base(builderField, targetField, message, innerException)
        {
        }
    }
}