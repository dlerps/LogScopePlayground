using Serilog.Core;
using Serilog.Events;

namespace Playground.Custom
{
    public class CustomScopeEnricher : ILogEventEnricher
    {
        private readonly CustomLogScope _scope;

        public CustomScopeEnricher(CustomLogScope scope)
        {
            _scope = scope;
        }

        public void Enrich(LogEvent logEvent, ILogEventPropertyFactory propertyFactory)
        {
            foreach (var scopePropertyKey in _scope.ScopeProperties.Keys)
            {
                logEvent.AddOrUpdateProperty(
                    propertyFactory.CreateProperty(scopePropertyKey, _scope.ScopeProperties[scopePropertyKey], true)
                );
            }
        }
    }
}