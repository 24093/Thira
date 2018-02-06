﻿using System;
using Alkl.Thira.DomainObjects;

namespace Alkl.Thira.Exceptions
{
    internal abstract class InvalidMoveException : InvalidOperationException
    {
        public readonly Field FieldFrom;
        public readonly Field FieldTo;

        protected InvalidMoveException(Field from, Field to, string message = null, Exception innerException = null)
            : base(message, innerException)
        {
            FieldFrom = from;
            FieldTo = to;
        }
    }
}