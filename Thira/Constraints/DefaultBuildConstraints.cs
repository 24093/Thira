using Alkl.Thira.DomainObjects;
using Alkl.Thira.Exceptions;
using Alkl.Thira.Exceptions.BuildExceptions;

namespace Alkl.Thira.Constraints
{
    internal class DefaultBuildConstraints : IBuildConstraints
    {
        public void CheckBuild(Field builderField, Field targetField)
        {
            CheckArguments(builderField, targetField);

            if (!builderField.Position.IsNeighbor(targetField.Position))
                throw new TargetFieldIsNotNeighborOfBuilderFieldException(builderField, targetField);

            if (targetField.Builder != null)
                throw new TargetFieldContainsBuilderException(builderField, targetField);
        }

        public IBuildConstraints DeepClone()
        {
            return new DefaultBuildConstraints();
        }

        protected void CheckArguments(Field builderField, Field targetField)
        {
            if (builderField == null) throw new BuilderFieldDoesNotExistException(null, targetField);

            if (targetField == null) throw new TargetFieldDoesNotExistException(builderField, null);

            if (targetField.Builder == null) throw new NoBuilderOnBuilderFieldException(builderField, targetField);
        }
    }
}