using Microsoft.EntityFrameworkCore;
using Moq;
using Xunit;
using SignalR_UnitTestingSupportXUnit.Services;
using System;

namespace SignalR_UnitTestingSupportXUnit.Hubs
{
    /// <summary>
    /// Hub unit tests base with Entity Framework Core
    /// </summary>
    public class HubUnitTestsWithEF<TDbContext> : HubUnitTestsBase, IDisposable
        where TDbContext : DbContext
    {
        DbMockAndInMemoryProvider<TDbContext> _dbProvider = new DbMockAndInMemoryProvider<TDbContext>();

        /// <summary>
        /// By default, pure TDbContext mock, without any setup.
        /// </summary>
        public Mock<TDbContext> DbContextMock
        {
            get
            {
                return _dbProvider.DbContextMock;
            }
        }

        /// <summary>
        /// Relational database in memory
        /// </summary>
        public TDbContext DbInMemorySqlite
        {
            get
            {
                return _dbProvider.DbInMemorySqlite;
            }
        }

        /// <summary>
        /// Database in memory (not really relational)
        /// <para>For more info: https://docs.microsoft.com/pl-pl/ef/core/miscellaneous/testing/in-memory </para>
        /// </summary>
        public TDbContext DbInMemory
        {
            get
            {
                return _dbProvider.DbInMemory;
            }
        }

        public HubUnitTestsWithEF()
        {
            _dbProvider.SetUp();
        }

        public new void Dispose()
        {
            _dbProvider.TearDown();
        }
    }
}
