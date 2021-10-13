using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;

namespace Playground.ErrorHandling
{
    public class ErrorFilter : IExceptionFilter
    {
        private readonly ILogger<ErrorFilter> _logger;

        public ErrorFilter(ILogger<ErrorFilter> logger)
        {
            _logger = logger;
        }

        public void OnException(ExceptionContext context)
        {
            if (context?.Exception == null)
                return;
            
            _logger.LogError(context.Exception, "Something went terribly wrong....");
            context.ExceptionHandled = true;
        }
    }
}