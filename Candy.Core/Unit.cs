using System;

namespace Candy
{
    public class Unit
    {
        private static readonly Lazy<Unit> _default =
            new Lazy<Unit>(() => new Unit(), true);

        public static Unit Default => _default.Value;
    }
}