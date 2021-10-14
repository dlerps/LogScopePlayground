using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Serilog;
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
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Override("Microsoft", LogEventLevel.Information)
                .Enrich.FromLogContext()
                .Enrich.With(customScopeEnricher)
                .WriteTo.Console(new RenderedCompactJsonFormatter())
                .CreateLogger();

            await _next(httpContext);
            
            // after
        }
    }
}