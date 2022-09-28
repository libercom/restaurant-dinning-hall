using DinningHall.Constants;
using DinningHall.Data;
using Newtonsoft.Json;

namespace DinningHall.Models
{
    public class Table
    {
        private readonly Menu _menu;
        private readonly ILogger<Table> _logger;
        private readonly string _apiEndpoint;

        public Guid TableId { get; set; }
        public Order Order { get; set; }
        public Waiter Waiter { get; set; }
        public Table(Menu menu, Waiter waiter, ILogger<Table> logger, string apiEndpoint)
        {
            _menu = menu;
            _logger = logger;
            _apiEndpoint = apiEndpoint;

            Waiter = waiter;
            TableId = Guid.NewGuid();
        }

        public async Task Start()
        {
            while (true)
            {
                await Task.Delay(WaitToPickOrder() * 1000);
                GenerateOrder();

                Waiter.TakeOrder(Order, _apiEndpoint);

                WaitForOrder();
            }
        }

        public void WaitForOrder()
        {
            while (Order.OrderStatus != OrderStatus.Served)
            {
                // todo
            }
        }

        public void GenerateOrder()
        {
            Order = new Order() { OrderId = Guid.NewGuid() };

            Order.OrderStatus = OrderStatus.InProgress;

            Order.OrderItems.Add(PickRandomMenuItem());
            Order.OrderItems.Add(PickRandomMenuItem());
            Order.OrderItems.Add(PickRandomMenuItem());
        }

        public MenuItem PickRandomMenuItem()
        {
            Random random = new Random();
            int menuItemId = random.Next(1, 14);

            return _menu.MenuItems[menuItemId - 1];
        }

        public int WaitToPickOrder()
        {
            Random random = new Random();

            int timeToWait = random.Next(1, 4);

            return timeToWait;
        }

        public void RateService()
        {
            // todo
        }
    }
}
