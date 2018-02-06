using System;
using Alkl.Thira.DomainObjects;

namespace Alkl.Thira.Exceptions
{
    internal abstract class BuildException : InvalidOperationException
    {
        public readonly Field BuilderField;
        public readonly Field TargetField;

        protected BuildException(Field builderField, Field targetField, string message = null, Exception innerException = null)
            : base(message, innerException)
        {
            BuilderField = builderField;
            TargetField = targetField;
        }
    }
}