using System;
using Alkl.Thira.DomainObjects;

namespace Alkl.Thira.Exceptions
{
    public class DestinationFieldIsNotEmptyException : InvalidMoveException
    {
        public DestinationFieldIsNotEmptyException(Player player = null, Field from = null, Field to = null,
            string message = null, Exception innerException = null)
            : base(player, from, to, message, innerException)
        {
        }
    }
}