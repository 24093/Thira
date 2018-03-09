using Alkl.Thira.DomainObjects;

namespace Alkl.Thira.Constraints
{
    internal interface IBuildConstraints : IDeepCloneable<IBuildConstraints>
    {
        IResult<CheckBuildError> CheckBuild(Field builderField, Field targetField, uint maxLevel);
    }
}