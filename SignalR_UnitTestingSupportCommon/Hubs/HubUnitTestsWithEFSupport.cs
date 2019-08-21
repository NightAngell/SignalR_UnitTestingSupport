using Microsoft.EntityFrameworkCore;
using Moq;
using SignalR_UnitTestingSupportCommon.Interfaces;
using SignalR_UnitTestingSupportCommon.EFSupport;

namespace SignalR_UnitTestingSupportCommon.Hubs
{
    /// <summary>
    /// Base class which provide support for testing hub with EntityFramework Core (But without auto SetUp by any test engine)
    /// </summary>
    /// <typeparam name="TDbContext">DbContext child or DbContext itself</typeparam>
    public class HubUnitTestsWithEFSupport<TDbContext> : HubUnitTestsSupport, IHubUnitTestsWithEF<TDbContext>
        where TDbContext : DbContext
    {
        DbMockAndInMemoryProvider<TDbContext> _dbProvider = new DbMockAndInMemoryProvider<TDbContext>();

        /// <summary>
        /// Is false by default (<see cref="DbContext.Database.EnsureCreated()"/>).
        /// <para>Set it to true if you want use <see cref="DbContext.Database.Migrate()"/> instead.</para>
        /// <para>Warning! It NOT CREATE migrations. It only use existing ones.</para>
        /// </summary>
        public bool UseMigrations
        {
            get => _dbProvider.UseMigrations;
            set => _dbProvider.UseMigrations = value;
        }

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
        /// Set up all mocks and in memory db`s (Which are lazy loaded)
        /// </summary>
        public override void SetUp()
        {
            base.SetUp();
            _dbProvider.SetUp();
        }

        /// <summary>
        /// Clear after test 
        /// </summary>
        public virtual void TearDown()
        {
            _dbProvider.TearDown();
        }
    }
}
