using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using Xunit;

namespace Candy.Core.Tests
{
    public class CollectionsTests
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

        [Fact]
        public void TestFilter()
        {
            var arr = Utils.Range(0, 10);
            arr.Filter(x => x % 2 == 0).Should().Equal(0, 2, 4, 6, 8);
            arr.Filter(x => x % 3 == 0).Should().Equal(0, 3, 6, 9);

            var eachIndex = new List<int>();
            var greaterThenZeror = arr.Filter((x, i) => {
                i.AddInto(eachIndex);
                return x > 0;
            });
            greaterThenZeror.Should().Equal(1, 2, 3, 4, 5, 6, 7, 8, 9);
            eachIndex.Should().Equal(0, 1, 2, 3, 4, 5, 6, 7, 8, 9);
        }

        [Fact]
        public void TestMap()
        {
            var arr = Utils.Range(0, 5);
            arr.Map(x => x + 1).Should().Equal(1, 2, 3, 4, 5);
            arr.Map(x => x * x).Should().Equal(0, 1, 4, 9, 16);
            arr.Map((x, i) => x * i).Should().Equal(0, 1, 4, 9, 16);
        }

        [Fact]
        public void TestReduce()
        {
            var arr = Utils.Range(1, 5);
            arr.Reduce((r, x) => r + x).Should().Be(15);
            arr.Reduce((r, x) => r + x, 5).Should().Be(20);
        }
    }
}