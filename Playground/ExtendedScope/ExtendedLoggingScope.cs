using Microsoft.Extensions.Logging;

namespace Playground.ExtendedScope
{
    public class ExtendedLoggingScope
    {
        private readonly ExtendedLoggingScopeManager _manager;
        
        private readonly ILogger<ExtendedLoggingScope> _logger;

        public ExtendedLoggingScope(ExtendedLoggingScopeManager manager, ILogger<ExtendedLoggingScope> logger)
        {
            _manager = manager;
            _logger = logger;
        }

        public void Begin(string message, params object[] properties)
        {
            // ReSharper disable once TemplateIsNotCompileTimeConstantProblem
            _manager.Scope = _logger.BeginScope(message, properties);
        }
    }
}