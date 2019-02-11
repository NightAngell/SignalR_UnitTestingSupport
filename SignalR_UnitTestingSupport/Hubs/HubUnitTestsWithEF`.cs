using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;


namespace SignalR_UnitTestingSupport.Hubs
{
    /// <summary>
    /// Hub unit tests base with Entity Framework Core
    /// </summary>
    public abstract class HubUnitTestsWithEF<TIHubResponses, TDbContext>
        : HubUnitTestsBase<TIHubResponses>
        where TIHubResponses : class
        where TDbContext : DbContext
    {
        private Lazy<Mock<TDbContext>> _dbContextMockLazy;
        private Lazy<TDbContext> _dbInMemorySqliteLazy;
        private Lazy<TDbContext> _dbInMemoryInMemoryLazy;

        /// <summary>
        /// By default, pure DbContext mock, without any setup.
        /// </summary>
        protected Mock<TDbContext> _dbContextMock
        {
            get
            {
                return _dbContextMockLazy.Value;
            }
        }

        /// <summary>
        /// Relational database in memory
        /// </summary>
        protected TDbContext _dbInMemorySqlite
        {
            get
            {
                return _dbInMemorySqliteLazy.Value;
            }
        }

        /// <summary>
        /// Database in memory (not really relational)
        /// <para>For more info: https://docs.microsoft.com/pl-pl/ef/core/miscellaneous/testing/in-memory </para>
        /// </summary>
        protected TDbContext _dbInMemory
        {
            get
            {
                return _dbInMemoryInMemoryLazy.Value;
            }
        }

        [SetUp]
        public void EfSetUp()
        {
            if (_dbContextMockLazy == null || _dbContextMockLazy.IsValueCreated)
            {
                _dbContextMockLazy = new Lazy<Mock<TDbContext>>();
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

        [TearDown]
        public void TearDownEFContexts()
        {
            try
            {
                if (_dbInMemorySqliteLazy != null && _dbInMemorySqliteLazy.IsValueCreated)
                {
                    _dbInMemorySqlite.Dispose();
                }
            }
            catch(Exception)
            {
                //TODO: Add logger later
            }

            try
            {
                if (_dbInMemoryInMemoryLazy != null && _dbInMemoryInMemoryLazy.IsValueCreated)
                {
                    _dbInMemory.Dispose();
                }
            }
            catch (Exception)
            {
                //TODO: Add logger later
            }
        }

        private TDbContext _initInMemorySqlite()
        {
            var connection = new SqliteConnection("DataSource=:memory:");
            connection.Open();

            var dbContextSqliteOptions = new DbContextOptionsBuilder<TDbContext>()
                .UseSqlite(connection)
                .Options;

            var dbContext = (TDbContext)Activator.CreateInstance(typeof(TDbContext), dbContextSqliteOptions);
            dbContext.Database.EnsureCreated();

            return dbContext;
        }

        private TDbContext _initInMemoryInMemory()
        {
            var dbContextInMemoryOptions = new DbContextOptionsBuilder<TDbContext>()
                .UseInMemoryDatabase()
                .Options;
            
            var dbContext = (TDbContext)Activator.CreateInstance(typeof(TDbContext), dbContextInMemoryOptions);
            dbContext.Database.EnsureCreated();

            return dbContext;
        }
    }
}
