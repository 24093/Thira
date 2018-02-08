using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Alkl.Thira.UnitTests
{
    internal static class Util
    {
        public static Exception ContainsInnerException<T>(Exception exception)
        {
            if (exception.InnerException == null || exception.InnerException.GetType() != typeof(T))
            {
                throw new AssertFailedException();
            }

            return exception.InnerException;
        }
    }
}