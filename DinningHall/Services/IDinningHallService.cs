using DinningHall.Dtos;

namespace DinningHall.Services
{
    public interface IDinningHallService
    {
        void DistributeOrder(CompletedOrderDto completedOrderDto);
    }
}
