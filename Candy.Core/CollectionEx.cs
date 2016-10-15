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

        public static void AddRange<T>(this ICollection<T> source, IEnumerable<T> items)
        {
            foreach (var item in items) source.Add(item);
        }

        public static void AddRange<T>(this ICollection<T> source, params T[] items)
        {
            foreach (var item in items) source.Add(item);
        }

        public static T AddInto<T>(this T source, ICollection<T> collection)
        {
            collection.Add(source);
            return source;
        }

        public static T RemoveFrom<T>(this T source, ICollection<T> collection)
        {
            collection.Remove(source);
            return source;
        }
    }
}