using System;

namespace Candy.System
{
    public static class ObjectEx
    {
        public static T As<T>(this object x) => x is T ? (T)x : default(T);

        public static void TryDispose(this IDisposable x) 
        {
            try { x.Dispose(); } 
            catch {}
        } 
    }
}
