using DinningHall.Constants;
using System.Text;

namespace DinningHall.Models
{
    public class Order
    {
        public Guid OrderId { get; set; }
        public Guid TableId { get; set; }
        public List<MenuItem> OrderItems { get; set; }
        public OrderStatus OrderStatus { get; set; }

        public Order()
        {
            OrderId = Guid.NewGuid();
            OrderItems = new List<MenuItem>();
        }

        public override string ToString()
        {
            var order = OrderItems.Aggregate(new StringBuilder(), (a, b) => a.Append(", " + b.ToString()));
            
            return order.ToString();
        }
    }
}
