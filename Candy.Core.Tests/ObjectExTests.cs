using System;
using Xunit;

namespace Candy.Tests
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

        [Fact]
        public void TestTryDispose()
        {
            var x = new Foo();
            x.TryDispose();
            Assert.True(x.IsDisposed);

            var y = new Bar();
            y.TryDispose();
            Assert.True(true);
        }

        public interface IFoo { }
        public interface IBar { }

        public class Foo : IFoo, IDisposable 
        {
            public bool IsDisposed { get; private set; }
            public void Dispose() => IsDisposed = true;
        }

        public class Bar : IBar, IDisposable
        {
            public void Dispose()
            {
                throw new ObjectDisposedException("Bar");
            } 
        }
    }
}
