using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Playground.ExtendedScope;

namespace Playground.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TestController : ControllerBase
    {
        private readonly ExtendedLoggingScope _scope;
        
        private readonly ILogger<TestController> _logger;

        public TestController(ExtendedLoggingScope scope, ILogger<TestController> logger)
        {
            _scope = scope;
            _logger = logger;
        }

        [HttpGet("{input:alpha}")]
        public Task Get([FromRoute] string input)
        {
            _scope.Begin("{SCOPE}", "777777777777777777777777");
            _logger.LogInformation("{Input}", input);
            
            Inner();

            if (input == "abc")
                throw new InvalidOperationException("It's a trap!!");
            
            return Task.FromResult(NoContent());
        }

        private void Inner()
        {
            _scope.Begin("{Inner}", 123);
        }
    }
}
