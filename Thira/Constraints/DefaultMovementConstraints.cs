using Alkl.Thira.DomainObjects;
using Alkl.Thira.Exceptions;

namespace Alkl.Thira.Constraints
{
    public class DefaultMovementConstraints : IMovementConstraints
    {
        public virtual void CheckMove(Field fieldFrom, Field fieldTo)
        {
            CheckArguments(fieldFrom, fieldTo);
            
            if (!fieldFrom.Position.IsNeighbor(fieldTo.Position))
                throw new DestinationFieldIsNotNeighborOfSourceFieldException(fieldFrom, fieldTo);

            if (fieldTo.Builder != null) throw new DestinationFieldIsNotEmptyException(fieldFrom, fieldTo);
        }

        protected void CheckArguments(Field fieldFrom, Field fieldTo)
        {
            if (fieldFrom == null) throw new SourceFieldDoesNotExistException(null, fieldTo);

            if (fieldTo == null) throw new DestinationFieldDoesNotExistException(fieldFrom, fieldTo);

            if (fieldFrom.Builder == null) throw new NoBuilderOnSourceFieldException(fieldFrom, fieldTo);
        }

        public IMovementConstraints DeepClone()
        {
            return new DefaultMovementConstraints();
        }
    }
}