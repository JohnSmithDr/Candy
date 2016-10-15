using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
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

        [Fact]
        public void TestAddRangeFromEnumerable()
        {
            var col = new LinkedList<int>();
            col.AddRange(new List<int> { 0, 1, 2, 3, 4, 5 });
            col.Should().HaveCount(6).And.Equal(0, 1, 2, 3, 4, 5);
        }

        [Fact]
        public void TestAddRangeFromParams()
        {
            var col = new LinkedList<int>();
            col.AddRange(0, 1, 2, 3, 4, 5);
            col.Should().HaveCount(6).And.Equal(0, 1, 2, 3, 4, 5);
        }

        [Fact]
        public void TestAddInto()
        {
            var list = new List<int>();
            list.Should().HaveCount(0);

            Utils.Range(1, 4).ForEach(x => {
                x.AddInto(list).Should().Equals(x);
            });

            list.Should().HaveCount(4).And.Equal(1, 2, 3, 4);
        }

        [Fact]
        public void TestRemoveFrom()
        {
            var list = Utils.Range(1, 4).ToList();
            list.Should().HaveCount(4).And.Equal(1, 2, 3, 4);

            Utils.Range(1, 4).ForEach(x => {
                x.RemoveFrom(list).Should().Equals(x);
            });

            list.Should().HaveCount(0);
        }

        [Fact]
        public void TestIsNullOrEmpty()
        {
            int[] arr = null;
            arr.IsNullOrEmpty().Should().BeTrue();

            arr = new[] {0, 1, 2, 3};
            arr.IsNullOrEmpty().Should().BeFalse();
            
            var list = new List<int>();
            list.IsNullOrEmpty().Should().BeTrue();

            list.Add(1);
            list.IsNullOrEmpty().Should().BeFalse();
        }
    }
}