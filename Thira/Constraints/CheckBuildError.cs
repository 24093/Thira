namespace Alkl.Thira.Constraints
{
    public enum CheckBuildError
    {
        None,
        TargetFieldIsNotNeighborOfBuilderField,
        TargetFieldContainsBuilder,
        BuilderFieldDoesNotExist,
        NoBuilderOnBuilderField,
        TargetFieldDoesNotExist
    }
}