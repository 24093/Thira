using System;
using System.Collections.Generic;
using System.Linq;

namespace Alkl.Thira
{
    internal static class Extensions
    {
        public static T Random<T>(this IList<T> list)
        {
            var random = new Random();
            var index = random.Next(0, list.Count());
            return list.ElementAt(index);
        }
    }
}