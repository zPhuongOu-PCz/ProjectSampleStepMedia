using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using WebApi.Services;
using WebApi.Models;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api")]
    public class RandomController : ControllerBase
    {
        private readonly IRandomService _RandomService;

        public RandomController(IRandomService RandomService) { _RandomService = RandomService; }

        [HttpPost("random")]
        public IActionResult RandomArrayWithMaxNumberToMiddle([FromBody] RandomRequest request)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            var responseService = _RandomService.RandomListArrayNumber(request.number);
            stopwatch.Stop();
            var ts = stopwatch.Elapsed;
            if (string.IsNullOrEmpty(responseService))
                return BadRequest();
            return Ok(responseService);
        }
    }
}