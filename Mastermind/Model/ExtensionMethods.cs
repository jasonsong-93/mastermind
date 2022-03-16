using System;
using System.Collections.Generic;

namespace Mastermind.Model
{
    public static class ExtensionMethods
    {
        private static readonly Random Random = new();

        public static void ShuffleMe<T>(this IList<T> list)
        {
            var n = list.Count;
            while (n > 1)
            {
                n--;
                var k = Random.Next(n + 1);
                (list[k], list[n]) = (list[n], list[k]);
            }
        }
    }
}