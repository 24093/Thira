namespace Alkl.Thira.Constraints
{
    internal class CheckBuildResult : Result<CheckBuildError>
    {
        public CheckBuildResult()
        {
        }

        public CheckBuildResult(CheckBuildError error)
            : base(error)
        {
        }
        
        public static implicit operator CheckBuildResult(CheckBuildError error)
        {
            return new CheckBuildResult(error);
        }

        public override IResult<CheckBuildError> DeepClone()
        {
            return new CheckBuildResult(Error);
        }
    }
}