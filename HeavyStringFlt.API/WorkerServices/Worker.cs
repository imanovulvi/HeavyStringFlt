using HeavyStringFlt.API.Business.Abstraction;
using HeavyStringFlt.API.Business.Concret;

namespace HeavyStringFlt.API.WorkerServices
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly BackgroundQueue _backgroundQueue;
    

        public Worker(ILogger<Worker> logger, BackgroundQueue backgroundQueue)
        {
            _logger = logger;
            _backgroundQueue = backgroundQueue;
     
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            StringFilter stringFilter = new(new List<string> { "haker", "virus" });

            while (!stoppingToken.IsCancellationRequested)
            {
                string text = await _backgroundQueue.DequeueAsync(stoppingToken);
                if (text is not null)
                {

                    _logger.LogInformation(stringFilter.Filter(text));

                    
                    await Task.Delay(1000, stoppingToken);
                }
            }



        }
    }
}
