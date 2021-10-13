using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using Playground.ExtendedScope;

namespace Playground.ErrorHandling
{
    public class ErrorFilter : IExceptionFilter
    {
        private readonly ILogger<ErrorFilter> _logger;

        private readonly ExtendedLoggingScopeManager _loggingScopeManager;

        public ErrorFilter(ILogger<ErrorFilter> logger, ExtendedLoggingScopeManager loggingScopeManager)
        {
            _logger = logger;
            _loggingScopeManager = loggingScopeManager;
        }

        public void OnException(ExceptionContext context)
        {
            if (context?.Exception == null)
                return;
            
            _logger.LogError(context.Exception, "Something went terribly wrong....");
            context.ExceptionHandled = true;
            
            _loggingScopeManager.Scope?.Dispose();
        }
    }
}