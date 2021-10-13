using System;
using System.Collections.Generic;

namespace Playground.ExtendedScope
{
    public class ExtendedLoggingScopeManager
    {
        public IDisposable Scope { get; private set; }
        
        public string ScopeTemplate { get; private set; }

        public object[] ScopeParams => _scopeParams?.ToArray();

        private List<object> _scopeParams;

        public ExtendedLoggingScopeManager()
        {
            ScopeTemplate = String.Empty;
        }

        public void SetScope(IDisposable scope, string template, params object[] scopeParams)
        {
            Scope ??= scope;
            ScopeTemplate = $"{ScopeTemplate} {template}".Trim();
            AddScopeParams(scopeParams);
        }

        private void AddScopeParams(IEnumerable<object> parameters)
        {
            _scopeParams ??= new List<object>();
            _scopeParams.AddRange(parameters);
        }
    }
}