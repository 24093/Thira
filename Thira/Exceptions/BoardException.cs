﻿using System;

namespace Alkl.Thira.Exceptions
{
    internal abstract class BoardException : InvalidOperationException
    {
        protected BoardException(string message = null, Exception innerException = null)
            : base(message, innerException)
        {
        }
    }
}