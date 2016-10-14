using System.Collections.Generic;
using Xunit;

namespace Candy.Core.Tests
{
    public class CollectionExTests
    {
        [Fact]
        public void TestForEachForEnumerable()
        {
            int i = 0, j = 0;
            Utils.Range(0, 5).ForEach(x => i += x);
            Utils.Range(0, 5).ForEach((x, y) => j += (x * y));
            Assert.Equal(10, i);
            Assert.Equal(30, j);
        }

        [Fact]
        public void TestForEachForDictionary()
        {
            var dict = new Dictionary<int, int> {
                { 0, 0 },
                { 1, 1 },
                { 2, 4 },
                { 3, 9 },
                { 4, 16 },
                { 5, 25 }
            };
            dict.ForEach((key, val) => {
                Assert.Equal(key * key, val);
            });
            dict.ForEach((key, val, i) => {
                Assert.Equal(key, i);
                Assert.Equal(key * key, val);
            });
        }
    }
}