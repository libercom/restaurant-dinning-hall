using DinningHall.Constants;
using DinningHall.Dtos;
using Newtonsoft.Json;
using System.Text;

namespace DinningHall.Models
{
    public class Waiter
    {
        public Guid WaiterId { get; set; }
        public List<Order> Orders { get; set; }

        public Waiter()
        {
            WaiterId = Guid.NewGuid();
            Orders = new List<Order>();
        }

        public async Task TakeOrder(Order order, string endpoint)
        {
            HttpClient httpClient = new HttpClient();

            var orderDto = new OrderDto
            {
                OrderId = order.OrderId,
                WaiterId = WaiterId,
                TableId = order.TableId,
                Items = order.OrderItems.Select(x => x.MenuItemId).ToList(),
                MaxWait = order.OrderItems.Sum(x => x.PreparationTime),
                PickUpTime = DateTimeOffset.Now.ToUnixTimeMilliseconds(),
                Priority = 0
            };

            Orders.Add(order);

            var serializedOrderDto = JsonConvert.SerializeObject(orderDto);

            await httpClient.PostAsync(endpoint, new StringContent(serializedOrderDto, Encoding.UTF8, "application/json"));
        }

        public void DistributeOrder(CompletedOrderDto completedOrderDto)
        {
            var order = Orders.FirstOrDefault(x => x.OrderId == completedOrderDto.OrderId);
            order.OrderStatus = OrderStatus.Served;
        }
    }
}
