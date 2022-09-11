using System.Text;

namespace DinningHall.Models
{
    public class Order
    {
        public List<OrderItem> OrderItems { get; set; }

        public override string ToString()
        {
            var order = OrderItems.Aggregate(new StringBuilder(), (a, b) => a.Append(", " + b.ToString()));
            
            return order.ToString();
        }
    }
}
