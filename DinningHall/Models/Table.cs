namespace DinningHall.Models
{
    public class Table
    {
        public Guid Id { get; set; }

        public Table()
        {
            Id = Guid.NewGuid();
        }

        public async Task<int> GenerateOrder()
        {
            var rnd = new Random();
            var timeToWait = rnd.Next(1, 4);

            await Task.Delay(timeToWait * 1000);

            return timeToWait;
        }
    }

    enum TableState
    {
        ChoosingOrder,
        WaitingToMakeOrder,
        WaitingForOrder
    }
}
