using DinningHall.Dtos;
using DinningHall.Services;
using Microsoft.AspNetCore.Mvc;

namespace DinningHall.Controllers
{
    [ApiController]
    [Route("api")]
    public class BaseController : ControllerBase
    {
        private readonly ILogger<BaseController> _logger;
        private readonly IDinningHallService _dinningHallService;

        public BaseController(ILogger<BaseController> logger, IDinningHallService dinningHallService)
        {
            _logger = logger;
            _dinningHallService = dinningHallService;
        }

        [HttpPost("distribution")]
        public IActionResult DistributeOrder(CompletedOrderDto completedOrderDto)
        {
            _logger.LogInformation($"Dinning Hall: Recieved order with id: {completedOrderDto.OrderId}");
            _dinningHallService.DistributeOrder(completedOrderDto);

            return Ok();
        }
    }
}
