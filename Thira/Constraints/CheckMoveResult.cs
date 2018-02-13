namespace Alkl.Thira.Constraints
{
    internal class CheckMoveResult : Result<CheckMoveError>
    {
        public CheckMoveResult()
        {
        }

        public CheckMoveResult(CheckMoveError error)
            : base(error)
        {
        }

        public static implicit operator CheckMoveResult(CheckMoveError error)
        {
            return new CheckMoveResult(error);
        }

        public override IResult<CheckMoveError> DeepClone()
        {
            return new CheckMoveResult(Error);
        }
    }
}