using DinningHall.Models;
using System.Collections.Generic;

namespace DinningHall.Services
{
    public class TestService : BackgroundService
    {
        private readonly ILogger<TestService> _logger;
        private IList<Table> _tables = new List<Table>()
        {
            new Table(),
            new Table()
        };

        public TestService(ILogger<TestService> logger)
        {
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            foreach (var table in _tables)
            {
                Task.Run(async () =>
                {
                    var timeToWait = await table.GenerateOrder();

                    _logger.LogInformation($"{table.Id} ordered something after {timeToWait}");
                }, stoppingToken);
            }

            //while (!stoppingToken.IsCancellationRequested)
            //{
            //    await Task.Delay(1000);
            //}
        }
    }
}
