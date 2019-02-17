using Microsoft.EntityFrameworkCore;
using Moq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SignalR_UnitTestingSupport.Services;

namespace SignalR_UnitTestingSupport.Hubs
{
    /// <summary>
    /// Hub unit tests base with Entity Framework Core
    /// </summary>
    public class HubUnitTestsWithEF<TDbContext> : HubUnitTestsBase
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

        /// <summary>
        /// NUnit SetUp for HubUnitTestsWithEf`. Only NUnit should call this method.
        /// </summary>
        [TestInitialize]
        public void EfSetUp()
        {
            _dbProvider.SetUp();
        }

        /// <summary>
        /// NUnit TearDown for HubUnitTestsWithEf`. Only NUnit should call this method.
        /// </summary>
        [TestCleanup]
        public void TearDownEFContexts()
        {
            _dbProvider.TearDown();
        }
    }
}
