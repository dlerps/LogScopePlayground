using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Playground.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TestController : ControllerBase
    {
        private readonly ILogger<TestController> _logger;

        public TestController(ILogger<TestController> logger)
        {
            _logger = logger;
        }

        [HttpGet("{input:alpha}")]
        public Task Get([FromRoute] string input)
        {
            using var ls = _logger.BeginScope("{SCOPE}", "777777777777777777777777");
            _logger.LogInformation("{Input}", input);

            if (input == "abc")
                throw new InvalidOperationException("It's a trap!!");
            
            return Task.FromResult(NoContent());
        }
    }
}
