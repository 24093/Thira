using System;
using Alkl.Thira.DomainObjects;

namespace Alkl.Thira.Exceptions
{
    public abstract class InvalidMoveException : InvalidOperationException
    {
        public readonly Field FieldFrom;

        public readonly Field FieldTo;
        public readonly Player Player;

        protected InvalidMoveException(Player player = null, Field from = null, Field to = null, string message = null,
            Exception innerException = null)
            : base(message, innerException)
        {
            Player = player;
            FieldFrom = from;
            FieldTo = to;
        }
    }
}