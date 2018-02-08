﻿using System;

namespace Alkl.Thira.Exceptions.BoardExceptions
{
    public abstract class BoardException : InvalidOperationException
    {
        protected BoardException(string message = null, Exception innerException = null)
            : base(message, innerException)
        {
        }
    }
}