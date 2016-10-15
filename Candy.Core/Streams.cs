using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace Candy
{
    public static class Streams
    {
        public static async Task PipeToAsync(
            this Stream src, Stream dst, int bufferSize, CancellationToken cancellationToken, IProgress<int> progress)
        {
            var buffer = new byte[bufferSize];
            var read = 0;

            try
            {
                while ((read = await src.ReadAsync(buffer, 0, buffer.Length, cancellationToken)) > 0)
                {
                    cancellationToken.ThrowIfCancellationRequested();
                    await dst.WriteAsync(buffer, 0, read, cancellationToken);
                    await dst.FlushAsync(cancellationToken);
                    cancellationToken.ThrowIfCancellationRequested();
                    progress?.Report(read);
                }
            }
            catch
            {
                throw;
            }
            finally
            {
                buffer = null;
            }
        }
    }
}