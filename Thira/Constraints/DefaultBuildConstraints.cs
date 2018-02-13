using Alkl.Thira.DomainObjects;

namespace Alkl.Thira.Constraints
{
    internal class DefaultBuildConstraints : IBuildConstraints
    {
        public IResult<CheckBuildError> CheckBuild(Field builderField, Field targetField)
        {
            var checkArgumentsResult = CheckArguments(builderField, targetField);

            if (!checkArgumentsResult.Success)
                return checkArgumentsResult;

            if (!builderField.Position.IsNeighbor(targetField.Position))
                return new CheckBuildResult(CheckBuildError.TargetFieldIsNotNeighborOfBuilderField);

            if (targetField.Builder != null)
                return new CheckBuildResult(CheckBuildError.TargetFieldContainsBuilder);

            return new CheckBuildResult();
        }

        public IBuildConstraints DeepClone()
        {
            return new DefaultBuildConstraints();
        }

        protected CheckBuildResult CheckArguments(Field builderField, Field targetField)
        {
            if (builderField == null) return CheckBuildError.BuilderFieldDoesNotExist;

            if (builderField.Builder == null) return CheckBuildError.NoBuilderOnBuilderField;

            if (targetField == null) return CheckBuildError.TargetFieldDoesNotExist;

            return new CheckBuildResult();
        }
    }
}