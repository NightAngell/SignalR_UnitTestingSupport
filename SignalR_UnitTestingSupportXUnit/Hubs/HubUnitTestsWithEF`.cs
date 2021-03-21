using Microsoft.EntityFrameworkCore;
using SignalR_UnitTestingSupportCommon.Hubs;

namespace SignalR_UnitTestingSupportXUnit.Hubs
{
    /// <summary>
    /// Base class which provide support for Hub&lt;T&gt; testing with Entity Framework Core.
    /// </summary>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1649:File name should match first type name", Justification = "Legacy name")]
    public abstract class HubUnitTestsWithEF<TIHubResponses, TDbContext>
        : HubUnitTestsWithEFSupport<TIHubResponses, TDbContext>
        where TIHubResponses : class
        where TDbContext : DbContext
    {
        public HubUnitTestsWithEF()
        {
            SetUp();
        }

        /// <summary>
        /// Only xUnit should call this. Do not it directly.
        /// </summary>
        public void Dispose()
        {
            TearDown();
        }
    }
}
