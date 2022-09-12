using Microsoft.AspNetCore.Mvc;

namespace DinningHall.Controllers
{
    [ApiController]
    [Route("api")]
    public class BaseController : ControllerBase
    {
        private readonly ILogger<BaseController> _logger;

        public BaseController(ILogger<BaseController> logger)
        {
            _logger = logger;
        }

        [HttpPost("distribution")]
        public IActionResult DistributeOrder()
        {
            _logger.LogInformation("Order will be soon distributed");

            return Ok();
        }
    }
}
