using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using SignalR_UnitTestingSupportCommon.Hubs;

namespace SignalR_UnitTestingSupport.Hubs
{
    /// <summary>
    /// Base class which provide support for Hub&lt;T&gt; testing with Entity Framework Core.
    /// </summary>
#pragma warning disable SA1649 // File name should match first type name
    public abstract class HubUnitTestsWithEF<TIHubResponses, TDbContext>
#pragma warning restore SA1649 // File name should match first type name
        : HubUnitTestsWithEFSupport<TIHubResponses, TDbContext>
        where TIHubResponses : class
        where TDbContext : DbContext
    {
        /// <summary>
        /// Only NUnit Should Call it. Do not call it directly.
        /// </summary>
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        [SetUp]
        public void EfSetUp()
        {
            SetUp();
        }

        /// <summary>
        /// Only NUnit Should Call it. Do not call it directly.
        /// </summary>
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        [TearDown]
        public void TearDownEFContexts()
        {
            TearDown();
        }
    }
}
