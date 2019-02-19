using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using SignalR_UnitTestingSupportCommon.Hubs;

namespace SignalR_UnitTestingSupport.Hubs
{
    /// <summary>
    /// Base class which provide support for Hub testing with Entity Framework Core.
    /// </summary>
    public abstract class HubUnitTestsWithEF<TDbContext> : HubUnitTestsWithEFSupport<TDbContext>
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
