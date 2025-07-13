using System.Collections.Concurrent;

namespace HeavyStringFlt.API.Business.Concret
{
    public class BackgroundQueue
    {
        private readonly ConcurrentQueue<string> cq = new();
        private readonly SemaphoreSlim _signal = new(0);
        public void Enqueue(string item)
        {
            cq.Enqueue(item);
            _signal.Release();
        }
        public async Task<string> DequeueAsync(CancellationToken cancellationToken)
        {
            await _signal.WaitAsync(cancellationToken);

            cq.TryDequeue(out string s);
            return s;
        }


    }
}
