using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Moq;
using System;

namespace SignalR_UnitTestingSupportCommon.EFSupport
{
    /// <summary>
    /// Provide TDbContext mock, TDbContext InMemory and TDbContext Sqlite in memory.
    /// <para>https://docs.microsoft.com/pl-pl/ef/core/miscellaneous/testing/in-memory</para>
    /// <para>https://docs.microsoft.com/pl-pl/ef/core/miscellaneous/testing/sqlite</para>
    /// </summary>
    public class DbMockAndInMemoryProvider<TDbContext> where TDbContext : DbContext
    {
        private Lazy<Mock<TDbContext>> _dbContextMockLazy;
        private Lazy<TDbContext> _dbInMemorySqliteLazy;
        private Lazy<TDbContext> _dbInMemoryInMemoryLazy;

        /// <summary>
        /// Lazy loaded mock which has not any setup by default.
        /// </summary>
        public Mock<TDbContext> DbContextMock
        {
            get
            {
                return _dbContextMockLazy.Value;
            }
        }

        /// <summary>
        /// Lazy loaded TDbContext which enable tests with Sqlite in memory
        /// </summary>
        public TDbContext DbInMemorySqlite
        {
            get
            {
                return _dbInMemorySqliteLazy.Value;
            }
        }

        /// <summary>
        /// Lazy loaded TDbContext which enable tests with InMemory provider.
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
            try
            {
                if (_dbInMemorySqliteLazy != null && _dbInMemorySqliteLazy.IsValueCreated)
                {
                    DbInMemorySqlite.Dispose();
                }
            }
            catch (Exception)
            {
                //TODO: Add logger later
            }

            try
            {
                if (_dbInMemoryInMemoryLazy != null && _dbInMemoryInMemoryLazy.IsValueCreated)
                {
                    DbInMemory.Dispose();
                }
            }
            catch (Exception)
            {
                //TODO: Add logger later
            }
        }

        private Mock<TDbContext> _initDbContextMock()
        {
            return new Mock<TDbContext>(new DbContextOptions<TDbContext>());
        }

        private TDbContext _initInMemorySqlite()
        {
            //connection is closed automatically in TearDown when we dispose dbContext
            var connection = new SqliteConnection("DataSource=:memory:");
            connection.Open();
            var dbContextSqliteOptions = new DbContextOptionsBuilder<TDbContext>()
                .UseSqlite(connection)
                .ConfigureWarnings(x => x.Ignore(RelationalEventId.QueryClientEvaluationWarning))
                .Options;

            var dbContext = (TDbContext)Activator.CreateInstance(typeof(TDbContext), dbContextSqliteOptions);
            dbContext.Database.EnsureCreated();

            return dbContext;
        }

        private TDbContext _initInMemoryInMemory()
        {
            var dbContextInMemoryOptions = new DbContextOptionsBuilder<TDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .ConfigureWarnings(x => x.Ignore(RelationalEventId.QueryClientEvaluationWarning))
                .Options;

            var dbContext = (TDbContext)Activator.CreateInstance(typeof(TDbContext), dbContextInMemoryOptions);
            dbContext.Database.EnsureCreated();

            return dbContext;
        }
    }
}
