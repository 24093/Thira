using Alkl.Thira.DomainObjects;

namespace Alkl.Thira.Constraints
{
    public interface IMovementConstraints : IDeepCloneable<IMovementConstraints>
    {
        void CheckMove(Field fieldFrom, Field fieldTo);
    }
}