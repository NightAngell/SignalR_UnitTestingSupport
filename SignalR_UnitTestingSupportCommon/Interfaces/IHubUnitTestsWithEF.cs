using Microsoft.EntityFrameworkCore;
using Moq;

namespace SignalR_UnitTestingSupportCommon.Interfaces
{
    /// <summary>
    /// To be sure we implement all features for testing pure Hub (or Hub&lt;T&gt;) plus entity framework core
    /// </summary>
    public interface IHubUnitTestsWithEF<TDbContext> : ISetUpForUserAndEngine
        where TDbContext : DbContext
    {
        /// <summary>
        /// Mock for TDbContext which is DbContext child or DbContext itself
        /// </summary>
        Mock<TDbContext> DbContextMock { get; }

        /// <summary>
        /// DbContext child or DbContext itself which use InMemoryProvider (not really relatonal).
        /// <para>https://docs.microsoft.com/pl-pl/ef/core/miscellaneous/testing/in-memory</para>
        /// </summary>
        TDbContext DbInMemory { get; }

        /// <summary>
        /// DbContext child or DbContext itself which use Sqlite provider configured to run in db in memory (relatonal).
        /// <para>https://docs.microsoft.com/pl-pl/ef/core/miscellaneous/testing/sqlite</para>
        /// </summary>
        TDbContext DbInMemorySqlite { get; }

        /// <summary>
        /// Tear Down object. Prepared for testing engine 
        /// or user which decided use class which implement that interfeca as object.
        /// (instead use one of provided base classes [NUnit, xUnit, MsTest])
        /// </summary>
        void TearDown();
    }
}