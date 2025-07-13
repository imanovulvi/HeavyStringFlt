using HeavyStringFlt.API.Business.Concret;

namespace HeavyStringFlt.Tests
{
    public class BackgroundQueueTests
    {
        [Fact]
        public async Task Enqueue_Then_Dequeue_ReturnsSameItem()
        {

            var queue = new BackgroundQueue();


            queue.Enqueue("hello");

            var result = await queue.DequeueAsync(CancellationToken.None);

            Assert.Equal("hello", result);
        }

        [Fact]
        public async Task DequeueAsync_WaitsUntilItemIsAvailable()
        {

            var queue = new BackgroundQueue();
            var cts = new CancellationTokenSource();


            queue.Enqueue("delayed");

            var result = await queue.DequeueAsync(cts.Token); ;


            Assert.Equal("delayed", result);
        }
    }
}