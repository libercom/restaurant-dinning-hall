using DinningHall.Data;
using DinningHall.Dtos;
using DinningHall.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Text;

namespace DinningHall.Services
{
    public class DinningHallService : IDinningHallService
    {
        private readonly Menu _menu;

        private readonly ILogger<DinningHallService> _logger;
        private readonly string _apiEndpoint;

        public List<Table> Tables { get; set; }
        public List<Waiter> Waiters { get; set; }

        public DinningHallService(ILogger<DinningHallService> logger, ILogger<Table> tableLogger, IConfiguration configuration, Menu menu)
        {
            _logger = logger;
            _menu = menu;
            _apiEndpoint = configuration.GetSection("KitchenEndpoint").Value;

            Waiters = new List<Waiter>()
            {
                new Waiter(),
                new Waiter(),
                new Waiter(),
            };

            Tables = new List<Table>()
            {
                new Table(_menu, Waiters[0], tableLogger, _apiEndpoint),
                new Table(_menu, Waiters[1], tableLogger, _apiEndpoint),
                new Table(_menu, Waiters[2], tableLogger, _apiEndpoint),
            };


            foreach (var table in Tables)
            {
                Task.Run(table.Start);
            }

            Task.Run(Start);
        }

        public async Task Start()
        {
            while (true)
            {
                await Task.Delay(1);
            }
        }

        public void DistributeOrder(CompletedOrderDto completedOrderDto)
        {
            var waiter = Waiters.FirstOrDefault(x => x.WaiterId == completedOrderDto.WaiterId);

            waiter.DistributeOrder(completedOrderDto);
        }
    }
}
