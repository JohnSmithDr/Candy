using System.Linq;
using Xunit;

namespace Candy.Core.Tests
{
    public class UtilsTest
    {
        [Theory]
        [InlineData(0, 5, new int[] { 0, 1, 2, 3, 4 })]
        [InlineData(1, 5, new int[] { 1, 2, 3, 4, 5 })]
        [InlineData(-1, 5, new int[] { -1, 0, 1, 2, 3 })]
        public void TestRange(int begin, int count, int[] expected)
        {
            Assert.Equal(expected, Utils.Range(begin, count).ToArray());
        }

        [Theory]
        [InlineData(0, 5, 1, new int[] { 0, 1, 2, 3, 4, 5 })]
        [InlineData(0, 5, 2, new int[] { 0, 2, 4 })]
        [InlineData(0, 6, 3, new int[] { 0, 3, 6 })]
        public void TestRangeInclude(int begin, int end, int step, int[] expected)
        {
            Assert.Equal(expected, Utils.RangeInclude(begin, end, step).ToArray());
        }

        [Theory]
        [InlineData(0, 5, 1, new int[] { 0, 1, 2, 3, 4 })]
        [InlineData(0, 5, 2, new int[] { 0, 2, 4 })]
        [InlineData(0, 6, 3, new int[] { 0, 3 })]
        public void TestRangeExclude(int begin, int end, int step, int[] expected)
        {
            Assert.Equal(expected, Utils.RangeExclude(begin, end, step).ToArray());
        }
    }
}