using Alkl.Thira.DomainObjects;

namespace Alkl.Thira.Constraints
{
    internal interface IMovementConstraints : IDeepCloneable<IMovementConstraints>
    {
        void CheckMove(Field fieldFrom, Field fieldTo);
    }
}