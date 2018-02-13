namespace Alkl.Thira.Constraints
{
    internal abstract class Result<TError> : IResult<TError>
    {
        public bool Success { get; protected set; }

        public TError Error { get; protected set; }
        
        protected Result(TError error = default(TError))
        {
            Success = error.Equals(default(TError));
            Error = error;
        }

        public abstract IResult<TError> DeepClone();

        public override string ToString()
        {
            return Error.ToString();
        }
    }
}