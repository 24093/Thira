using Alkl.Thira.DomainObjects;

namespace Alkl.Thira.Constraints
{
    internal interface IResult<TError> : IDeepCloneable<IResult<TError>>
    {
        bool Success { get; }

        TError Error { get; }
    }
}