using Alkl.Thira.DomainObjects;

namespace Alkl.Thira.Constraints
{
    internal class DefaultMovementConstraints : IMovementConstraints
    {
        public virtual IResult<CheckMoveError> CheckMove(Field fieldFrom, Field fieldTo)
        {
            var checkArgumentsResult = CheckArguments(fieldFrom, fieldTo);

            if (!checkArgumentsResult.Success)
            {
                return checkArgumentsResult;
            }

            if (!fieldFrom.Position.IsNeighbor(fieldTo.Position))
                return new CheckMoveResult(CheckMoveError.DestinationFieldIsNotNeighborOfSourceField);

            if (fieldTo.Builder != null) return new CheckMoveResult(CheckMoveError.DestinationFieldIsNotEmpty);

            return new CheckMoveResult();
        }

        public IMovementConstraints DeepClone()
        {
            return new DefaultMovementConstraints();
        }

        protected CheckMoveResult CheckArguments(Field fieldFrom, Field fieldTo)
        {
            if (fieldFrom == null) return CheckMoveError.SourceFieldDoesNotExist;

            if (fieldTo == null) return CheckMoveError.DestinationFieldDoesNotExist;

            if (fieldFrom.Builder == null) return CheckMoveError.NoBuilderOnSourceField;

            return new CheckMoveResult();
        }
    }
}