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
    abstract class HubUnitTestsWithEF<TIHubResponses, TDbContext>
        : HubUnitTestsBase<TIHubResponses>
        where TIHubResponses : class
        where TDbContext : DbContext
    {
        protected Mock<TDbContext> _dbContextMock;

        private Lazy<TDbContext> _dbInMemorySqliteLazy;

        private Lazy<TDbContext> _dbInMemoryInMemoryLazy;

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
            _dbContextMock = new Mock<TDbContext>();
            _dbInMemorySqliteLazy = new Lazy<TDbContext>(_initInMemorySqlite);
            _dbInMemoryInMemoryLazy = new Lazy<TDbContext>(_initInMemoryInMemory);
        }

        [TearDown]
        public void TearDownEFContexts()
        {
            try
            {
                if (_dbInMemorySqliteLazy.IsValueCreated)
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
                if (_dbInMemoryInMemoryLazy.IsValueCreated)
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
            var dbContextSqliteOptions = new DbContextOptionsBuilder<TDbContext>()
                .UseSqlite("DataSource=:memory:")
                .Options;

            var dbContext = new DbContext(dbContextSqliteOptions) as TDbContext;
            dbContext.Database.EnsureCreated();

            return dbContext;
        }

        private TDbContext _initInMemoryInMemory()
        {
            var dbContextInMemoryOptions = new DbContextOptionsBuilder<TDbContext>()
                .UseInMemoryDatabase()
                .Options;

            var dbContext = new DbContext(dbContextInMemoryOptions) as TDbContext;
            dbContext.Database.EnsureCreated();

            return dbContext;
        }
    }
}
