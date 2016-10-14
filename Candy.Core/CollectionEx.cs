using System;
using System.Collections.Generic;

namespace Candy
{
    public static class CollectionEx
    {
        public static IEnumerable<T> ForEach<T>(this IEnumerable<T> source, Action<T> handler)
        {
            foreach (var item in source) handler.Invoke(item);
            return source;
        }

        public static IEnumerable<T> ForEach<T>(this IEnumerable<T> source, Action<T, int> handler)
        {
            var i = 0;
            foreach (var item in source) handler.Invoke(item, i++);
            return source;
        }
    }
}