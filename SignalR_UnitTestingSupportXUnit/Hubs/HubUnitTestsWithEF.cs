using System;
using Microsoft.EntityFrameworkCore;
using SignalR_UnitTestingSupportCommon.Hubs;

namespace SignalR_UnitTestingSupportXUnit.Hubs
{
    /// <summary>
    /// Base class which provide support for Hub testing with Entity Framework Core.
    /// </summary>
    public abstract class HubUnitTestsWithEF<TDbContext> : HubUnitTestsWithEFSupport<TDbContext>, IDisposable
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
