using Candy.System;
using Xunit;

namespace Tests
{
    public class ObjectExTests
    {
        [Fact]
        public void TestAs() 
        {
            var x = new Foo();
            Assert.NotNull(x.As<IFoo>());
            Assert.Null(x.As<IBar>());
        }

        public interface IFoo { }
        public interface IBar { }
        public class Foo : IFoo { }
    }
}
