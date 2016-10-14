using Xunit;

namespace Candy.Core.Tests
{
    public class CollectionExTests
    {
        [Fact]
        public void TestForEach()
        {
            int i = 0, j = 0;
            Utils.Range(0, 5).ForEach(x => i += x);
            Utils.Range(0, 5).ForEach((x, y) => j += (x * y));
            Assert.Equal(10, i);
            Assert.Equal(30, j);
        }
    }
}