using Alkl.Thira.DomainObjects;

namespace Alkl.Thira.Constraints
{
    public interface IBuildConstraints : IDeepCloneable<IBuildConstraints>
    {
        void CheckBuild(Builder builder, Field field);
    }
}