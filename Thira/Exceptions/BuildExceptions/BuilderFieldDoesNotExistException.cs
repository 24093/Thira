using System;
using Alkl.Thira.DomainObjects;

namespace Alkl.Thira.Exceptions.BuildExceptions
{
    internal class BuilderFieldDoesNotExistException : BuildException
    {
        public BuilderFieldDoesNotExistException(Field builderField, Field targetField, string message = null,
            Exception innerException = null)
            : base(builderField, targetField, message, innerException)
        {
        }
    }
}