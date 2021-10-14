using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Playground.Custom;

namespace Playground.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TestController : ControllerBase
    {
        private readonly ILogger<TestController> _logger;

        private readonly CustomLogScope _customLogScope;

        public TestController(ILogger<TestController> logger, CustomLogScope customLogScope)
        {
            _logger = logger;
            _customLogScope = customLogScope;
        }

        [HttpGet("{input:alpha}")]
        public Task Get([FromRoute] string input)
        {
            _customLogScope.With("SCOPE", "777777777777777777777777");
            _logger.LogInformation("{Input}", input);

            if (input == "abc")
                throw new InvalidOperationException("It's a trap!!");
            
            return Task.FromResult(NoContent());
        }
    }
}
