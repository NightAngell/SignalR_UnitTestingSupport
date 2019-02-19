using SignalR_UnitTestingSupportCommon.Hubs;
using System;

namespace SignalR_UnitTestingSupportXUnit.Hubs
{
    /// <summary>
    /// Base class which provide support for Hub&lt;T&gt; testing
    /// </summary>
    /// <typeparam name="TIHubResponses">Interface which is used in Hub&lt;T&gt; as T</typeparam>
    public abstract class HubUnitTestsBase<TIHubResponses> : HubUnitTestsSupport<TIHubResponses>, IDisposable
        where TIHubResponses : class
    {
        #pragma warning disable CS1591
        public HubUnitTestsBase()
        {
            SetUp();
        }
        #pragma warning restore CS1591

        /// <summary>
        /// Only xUnit should call this. Do not it directly.
        /// </summary>
        public virtual void Dispose()
        {
            //Nothing to dispose here
        }
    }
}
