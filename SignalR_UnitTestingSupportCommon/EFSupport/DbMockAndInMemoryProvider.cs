using System;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Moq;

namespace SignalR_UnitTestingSupportCommon.EFSupport
{
    /// <summary>
    /// Provide TDbContext mock, TDbContext InMemory and TDbContext Sqlite in memory.
    /// <para>https://docs.microsoft.com/pl-pl/ef/core/miscellaneous/testing/in-memory</para>
    /// <para>https://docs.microsoft.com/pl-pl/ef/core/miscellaneous/testing/sqlite</para>
    /// </summary>
    public class DbMockAndInMemoryProvider<TDbContext>
        where TDbContext : DbContext
    {
        private Lazy<Mock<TDbContext>> _dbContextMockLazy;
        private Lazy<TDbContext> _dbInMemorySqliteLazy;
        private Lazy<TDbContext> _dbInMemoryInMemoryLazy;

        /// <summary>
        /// Gets lazy loaded mock which has not any setup by default.
        /// </summary>
        public Mock<TDbContext> DbContextMock
        {
            get
            {
                return _dbContextMockLazy.Value;
            }
        }

        /// <summary>
        /// Gets lazy loaded TDbContext which enable tests with Sqlite in memory
        /// </summary>
        public TDbContext DbInMemorySqlite
        {
            get
            {
                return _dbInMemorySqliteLazy.Value;
            }
        }

        /// <summary>
        /// Gets lazy loaded TDbContext which enable tests with InMemory provider.
        /// </summary>
        public TDbContext DbInMemory
        {
            get
            {
                return _dbInMemoryInMemoryLazy.Value;
            }
        }

        /// <summary>
        /// Use it before any test when you want use features provided by provider.
        /// </summary>
        public void SetUp()
        {
            if (_dbContextMockLazy == null || _dbContextMockLazy.IsValueCreated)
            {
                _dbContextMockLazy = new Lazy<Mock<TDbContext>>(_initDbContextMock);
            }

            if (_dbInMemorySqliteLazy == null || _dbInMemorySqliteLazy.IsValueCreated)
            {
                _dbInMemorySqliteLazy = new Lazy<TDbContext>(_initInMemorySqlite);
            }

            if (_dbInMemoryInMemoryLazy == null || _dbInMemoryInMemoryLazy.IsValueCreated)
            {
                _dbInMemoryInMemoryLazy = new Lazy<TDbContext>(_initInMemoryInMemory);
            }
        }

        /// <summary>
        /// Use it after any test when you want use features provided by provider.
        /// </summary>
        public void TearDown()
        {
            if (_dbInMemorySqliteLazy != null && _dbInMemorySqliteLazy.IsValueCreated)
            {
                DbInMemorySqlite.Dispose();
            }

            if (_dbInMemoryInMemoryLazy != null && _dbInMemoryInMemoryLazy.IsValueCreated)
            {
                DbInMemory.Dispose();
            }
        }

        private Mock<TDbContext> _initDbContextMock()
        {
            return new Mock<TDbContext>(new DbContextOptions<TDbContext>());
        }

        private TDbContext _initInMemorySqlite()
        {
            // connection is closed automatically in TearDown when we dispose dbContext
            var connection = new SqliteConnection("DataSource=:memory:");
            connection.Open();
            var databaseContextSqliteOptions = new DbContextOptionsBuilder<TDbContext>()
                .UseSqlite(connection)
                .Options;

            return _createDb(databaseContextSqliteOptions);
        }

        private TDbContext _initInMemoryInMemory()
        {
            var databaseContextInMemoryOptions = new DbContextOptionsBuilder<TDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            return _createDb(databaseContextInMemoryOptions);
        }

        private TDbContext _createDb(DbContextOptions<TDbContext> databaseContextOptions)
        {
            var databaseContext = (TDbContext)Activator.CreateInstance(typeof(TDbContext), databaseContextOptions);
            databaseContext.Database.EnsureCreated();

            return databaseContext;
        }
    }
}
