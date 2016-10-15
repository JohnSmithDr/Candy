using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using FluentAssertions;
using Xunit;

namespace Candy.Core.Tests
{
    public class StreamsTests
    {
        [Fact]
        public async Task TestPipeAsync()
        {
            var data = new byte[409600];
            var random = new Random();
            random.NextBytes(data);
            using (var src = new MemoryStream(data))
            using (var dst = new MemoryStream(data.Length))
            {
                await src.PipeToAsync(dst, 4096, CancellationToken.None, null);
                dst.ToArray().Should().Equal(data);
            }
        }

        [Fact]
        public void TestPipeWithProgress()
        {
            var data = new byte[409600];
            var random = new Random();
            random.NextBytes(data);
            using (var sig = new AutoResetEvent(false))
            using (var src = new MemoryStream(data))
            using (var dst = new MemoryStream(data.Length))
            {
                var piped = 0;  
                var runTask = src.PipeToAsync(dst, 4096, CancellationToken.None, new Progress<int>(g => {
                    piped += g;
                    if (piped == data.Length) sig.Set();
                }));

                sig.WaitOne(5000);
                runTask.IsCompleted.Should().BeTrue();
                dst.ToArray().Should().Equal(data);
                piped.Should().Equals(data.Length);
            }
        }

        [Fact]
        public async Task TestPipeWithCancellation()
        {
            var data = new byte[409600];
            var random = new Random();
            random.NextBytes(data);
            using (var sig = new AutoResetEvent(false))
            using (var cts = new CancellationTokenSource())
            using (var src = new MemoryStream(data))
            using (var dst = new MemoryStream(data.Length))
            {
                var piped = 0;
                await Assert.ThrowsAnyAsync<OperationCanceledException>(async () => {
                    await src.PipeToAsync(dst, 1024, cts.Token, new Progress<int>(g => {
                        piped += g;
                        if (piped == 10240) cts.Cancel();
                    }));
                });
                piped.Should().BeLessThan(data.Length);
            }
        }
    }
}