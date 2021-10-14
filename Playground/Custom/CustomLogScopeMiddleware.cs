using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Serilog;
using Serilog.Context;
using Serilog.Events;
using Serilog.Formatting.Compact;

namespace Playground.Custom
{
    public class CustomLogScopeMiddleware
    {
        private readonly RequestDelegate _next;

        public CustomLogScopeMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext, CustomScopeEnricher customScopeEnricher)
        {
            // before
            using var scopeEnricher = LogContext.Push(customScopeEnricher);

            await _next(httpContext);
            
            // after
        }
    }
}