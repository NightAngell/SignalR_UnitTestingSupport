using Microsoft.EntityFrameworkCore;
using Moq;
using SignalR_UnitTestingSupportCommon.Hubs;
using SignalR_UnitTestingSupportCommon.Services;

namespace SignalR_UnitTestingSupportXUnit.Hubs
{
    /// <summary>
    /// Base class which provide support for Hub&lt;T&gt; testing with Entity Framework Core.
    /// </summary>
    public abstract class HubUnitTestsWithEF<TIHubResponses, TDbContext>
        : HubUnitTestsWithEFSupport<TIHubResponses, TDbContext>
        where TIHubResponses : class
        where TDbContext : DbContext
    {
        #pragma warning disable CS1591
        public HubUnitTestsWithEF()
        {
            SetUp();
        }
        #pragma warning restore CS1591

        /// <summary>
        /// Only xUnit should call this. Do not it directly.
        /// </summary>
        public void Dispose()
        {
            TearDown();
        }
    }
}
