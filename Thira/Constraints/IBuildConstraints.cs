using Alkl.Thira.DomainObjects;

namespace Alkl.Thira.Constraints
{
    public interface IBuildConstraints : IDeepCloneable<IBuildConstraints>
    {
        void CheckBuild(Field builderField, Field targetGield);
    }
}