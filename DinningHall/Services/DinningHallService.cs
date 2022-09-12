using DinningHall.Models;
using System.Collections.Generic;
using System.Text;

namespace DinningHall.Services
{
    public class DinningHallService : BackgroundService
    {
        private readonly ILogger<DinningHallService> _logger;
        private readonly string _apiEndpoint;

        public DinningHallService(ILogger<DinningHallService> logger, IConfiguration configuration)
        {
            _logger = logger;
            _apiEndpoint = configuration.GetSection("KitchenEndpoint").Value;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                var client = new HttpClient();

                await Task.Delay(3000);

                await client.PostAsync(_apiEndpoint, new StringContent("", Encoding.UTF8, "application/json"));
            }
        }
    }
}
