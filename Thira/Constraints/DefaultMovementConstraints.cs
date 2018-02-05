using Alkl.Thira.DomainObjects;
using Alkl.Thira.Exceptions;

namespace Alkl.Thira.Constraints
{
    public class DefaultMovementConstraints : IMovementConstraints
    {
        public virtual void CheckMove(Player player, Field fieldFrom, Field fieldTo)
        {
            if (fieldFrom.Builder.Owner.Name != player.Name)
                throw new BuilderDoesNotBelongToPlayerException(player, fieldFrom, fieldTo);

            if (!fieldFrom.Position.IsNeighbor(fieldTo.Position))
                throw new DestinationFieldIsNotNeighborOfSourceFieldException(player, fieldFrom, fieldTo);

            if (fieldTo.Builder != null) throw new DestinationFieldIsNotEmptyException(player, fieldFrom, fieldTo);
        }

        public void CheckArguments(Player player, Field fieldFrom, Field fieldTo)
        {
            if (player == null) throw new PlayerDoesNotExistException(null, fieldFrom, fieldTo);

            if (fieldFrom == null) throw new SourceFieldDoesNotExistException(player, null, fieldTo);

            if (fieldTo == null) throw new DestinationFieldDoesNotExistException(player, fieldFrom);

            if (fieldFrom.Builder == null) throw new NoBuilderOnSourceFieldException(player, fieldFrom, fieldTo);
        }

        public IMovementConstraints DeepClone()
        {
            return new DefaultMovementConstraints();
        }
    }
}