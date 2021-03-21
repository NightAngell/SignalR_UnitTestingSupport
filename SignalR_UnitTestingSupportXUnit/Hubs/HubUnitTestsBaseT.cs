using System;
using SignalR_UnitTestingSupportCommon.Hubs;

namespace SignalR_UnitTestingSupportXUnit.Hubs
{
    /// <summary>
    /// Base class which provide support for Hub&lt;T&gt; testing
    /// </summary>
    /// <typeparam name="TIHubResponses">Interface which is used in Hub&lt;T&gt; as T</typeparam>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1649:File name should match first type name", Justification = "Legacy name")]
    public abstract class HubUnitTestsBase<TIHubResponses> : HubUnitTestsSupport<TIHubResponses>, IDisposable
        where TIHubResponses : class
    {
        public HubUnitTestsBase()
        {
            SetUp();
        }

        /// <summary>
        /// Only xUnit should call this. Do not it directly.
        /// </summary>
        public virtual void Dispose()
        {
            // Nothing to dispose here
        }
    }
}
