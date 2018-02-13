using Alkl.Thira.DomainObjects;

namespace Alkl.Thira.Constraints
{
    internal interface IMovementConstraints : IDeepCloneable<IMovementConstraints>
    {
        IResult<CheckMoveError> CheckMove(Field fieldFrom, Field fieldTo);
    }
}