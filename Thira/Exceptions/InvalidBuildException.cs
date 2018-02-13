using System;
using Alkl.Thira.Constraints;

namespace Alkl.Thira.Exceptions
{
    public class InvalidBuildException : BoardException<CheckBuildError>
    {
        public InvalidBuildException(CheckBuildError error, string message = null, Exception innerException = null)
            : base(error, message, innerException)
        {
        }
    }
}