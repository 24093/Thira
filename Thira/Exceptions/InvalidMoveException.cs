using System;
using Alkl.Thira.Constraints;

namespace Alkl.Thira.Exceptions
{
    public class InvalidMoveException : BoardException<CheckMoveError>
    {
        public InvalidMoveException(CheckMoveError error, string message = null, Exception innerException = null)
            : base(error, message, innerException)
        {
        }
    }
}