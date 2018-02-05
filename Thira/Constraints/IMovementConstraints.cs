using Alkl.Thira.DomainObjects;

namespace Alkl.Thira.Constraints
{
    public interface IMovementConstraints : IDeepCloneable<IMovementConstraints>
    {
        void CheckArguments(Player player, Field fieldFrom, Field fieldTo);

        void CheckMove(Player player, Field fieldFrom, Field fieldTo);
    }
}