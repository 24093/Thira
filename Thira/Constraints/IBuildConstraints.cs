using Alkl.Thira.DomainObjects;

namespace Alkl.Thira.Constraints
{
    internal interface IBuildConstraints : IDeepCloneable<IBuildConstraints>
    {
        void CheckBuild(Field builderField, Field targetField);
    }
}