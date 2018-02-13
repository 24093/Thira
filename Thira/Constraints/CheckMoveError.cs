namespace Alkl.Thira.Constraints
{
    public enum CheckMoveError
    {
        None,
        DestinationFieldIsNotNeighborOfSourceField,
        DestinationFieldIsNotEmpty,
        SourceFieldDoesNotExist,
        DestinationFieldDoesNotExist,
        NoBuilderOnSourceField
    }
}