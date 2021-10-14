using System.Collections.Generic;

namespace Playground.Custom
{
    public class CustomLogScope
    {
        public IDictionary<string, object> ScopeProperties { get; }

        public CustomLogScope()
        {
            ScopeProperties = new Dictionary<string, object>();
        }

        public CustomLogScope With(string key, object value)
        {
            if (!ScopeProperties.ContainsKey(key))
                ScopeProperties[key] = value;

            return this;
        }
    }
}