using System;
using System.Collections.Generic;
using System.Linq;

namespace Candy
{
    public static class Collections
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

        public static bool IsNullOrEmpty<T>(this IEnumerable<T> source)
        {
            return source == null || source.Any() == false;
        }

        public static IEnumerable<T> Filter<T>(this IEnumerable<T> source, Func<T, bool> filter) 
            => source.Where(filter);

        public static IEnumerable<T> Filter<T>(this IEnumerable<T> source, Func<T, int, bool> filter) 
            => source.Where(filter);
        
        public static IEnumerable<TOut> Map<TIn, TOut>(this IEnumerable<TIn> source, Func<TIn, TOut> mapper) 
            => source.Select(mapper);
        
        public static IEnumerable<TOut> Map<TIn, TOut>(this IEnumerable<TIn> source, Func<TIn, int, TOut> mapper) 
            => source.Select(mapper);
        
        public static T Reduce<T>(this IEnumerable<T> source, Func<T, T, T> reducer) 
            => source.Aggregate(reducer);
        
        public static TOut Reduce<T, TOut>(this IEnumerable<T> source, Func<TOut, T, TOut> reducer, TOut init) 
            => source.Aggregate(init, reducer);
    }
}