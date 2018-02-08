using System;
using Alkl.Thira.DomainObjects;

namespace Alkl.Thira.Exceptions.BuildExceptions
{
    internal class TargetFieldIsNotNeighborOfBuilderFieldException : BuildException
    {
        public TargetFieldIsNotNeighborOfBuilderFieldException(Field builderField, Field targetField,
            string message = null,
            Exception innerException = null)
            : base(builderField, targetField, message, innerException)
        {
        }
    }
    internal class TargetFieldContainsBuilderException : BuildException
    {
        public TargetFieldContainsBuilderException(Field builderField, Field targetField,
            string message = null,
            Exception innerException = null)
            : base(builderField, targetField, message, innerException)
        {
        }
    }
}