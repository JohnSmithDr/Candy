using System;
using System.Collections.Generic;

namespace Candy
{
    public static class CollectionEx
    {
        public static void ForEach<T>(this IEnumerable<T> source, Action<T> handler)
        {
            foreach (var item in source) handler.Invoke(item);
        }

        public static void ForEach<T>(this IEnumerable<T> source, Action<T, int> handler)
        {
            var i = 0;
            foreach (var item in source) handler.Invoke(item, i++);
        }

        public static void ForEach<TKey, TValue>(this IDictionary<TKey, TValue> source, Action<TKey, TValue> handler)
        {
            foreach (var item in source) handler.Invoke(item.Key, item.Value);
        }

        public static void ForEach<TKey, TValue>(this IDictionary<TKey, TValue> source, Action<TKey, TValue, int> handler)
        {
            var i = 0;
            foreach (var item in source) handler.Invoke(item.Key, item.Value, i++);
        }
    }
}