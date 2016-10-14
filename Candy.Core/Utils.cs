using System.Linq;
using System.Collections.Generic;

namespace Candy
{
    public static class Utils
    {
        public static IEnumerable<int> Range(int begin, int count)
        {
            return Enumerable.Range(begin, count);
        }

        public static IEnumerable<int> RangeInclude(int begin, int end, int step)
        {
            for (int i = begin; i <= end; i += step)
            {
                yield return i;
            }
        }

        public static IEnumerable<int> RangeExclude(int begin, int end, int step)
        {
            for (int i = begin; i < end; i += step)
            {
                yield return i;
            }
        }
    }
}