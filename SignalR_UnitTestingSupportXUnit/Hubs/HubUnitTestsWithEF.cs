using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using SignalR_UnitTestingSupportCommon.Services;
using SignalR_UnitTestingSupportCommon.Hubs;

namespace SignalR_UnitTestingSupportXUnit.Hubs
{
    /// <summary>
    /// Base class which provide support for Hub testing with Entity Framework Core.
    /// </summary>
    public abstract class HubUnitTestsWithEF<TDbContext> : HubUnitTestsWithEFSupport<TDbContext>, IDisposable
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
