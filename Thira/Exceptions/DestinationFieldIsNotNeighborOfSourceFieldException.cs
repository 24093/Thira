using System;
using Alkl.Thira.DomainObjects;

namespace Alkl.Thira.Exceptions
{
    internal class DestinationFieldIsNotNeighborOfSourceFieldException : InvalidMoveException
    {
        public DestinationFieldIsNotNeighborOfSourceFieldException(Field from, Field to, string message = null, Exception innerException = null)
            : base(from, to, message, innerException)
        {
        }
    }
}