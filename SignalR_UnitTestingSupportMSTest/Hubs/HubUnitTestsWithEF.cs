using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SignalR_UnitTestingSupportCommon.Hubs;

namespace SignalR_UnitTestingSupportMSTest.Hubs
{
    /// <summary>
    /// Hub unit tests base with Entity Framework Core
    /// </summary>
    public class HubUnitTestsWithEF<TDbContext> : HubUnitTestsWithEFSupport<TDbContext>
        where TDbContext : DbContext
    {
        /// <summary>
        /// Only MSTest Should Call it. Do not call it directly.
        /// </summary>
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        [TestInitialize]
        public void EfSetUp()
        {
            SetUp();
        }

        /// <summary>
        /// Only MSTest Should Call it. Do not call it directly.
        /// </summary>
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        [TestCleanup]
        public void TearDownEFContexts()
        {
            TearDown();
        }
    }
}
