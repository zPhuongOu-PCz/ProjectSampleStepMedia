using System.Diagnostics;
using WebApi.Services;
using WebApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api")]
    public class SortController : ControllerBase
    {
        private readonly ISortService _sortService;

        public SortController(ISortService sortService) { _sortService = sortService; }

        [HttpPost("sort")]
        public IActionResult SortArrayWithMaxNumberToMiddle([FromBody] SortRequest request)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            var responseService = _sortService.SortArrayWithMaxNumberToMiddle(request.arr, request.numberMax);
            stopwatch.Stop();
            var ts = stopwatch.Elapsed;
            if (string.IsNullOrEmpty(responseService))
                return BadRequest();
            var response = new SortReponse() { err = 0, msg = $@"Time : {ts.Milliseconds}ms", dt = responseService };
            return Ok(response);
        }
    }
}