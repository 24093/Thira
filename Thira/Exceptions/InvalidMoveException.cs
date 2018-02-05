using System;
using Alkl.Thira.DomainObjects;

namespace Alkl.Thira.Exceptions
{
    public abstract class InvalidMoveException : InvalidOperationException
    {
        public readonly Player Player;

        public readonly Field FieldFrom;

        public readonly Field FieldTo;

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