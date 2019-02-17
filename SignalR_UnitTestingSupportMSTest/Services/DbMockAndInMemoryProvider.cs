using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;

namespace SignalR_UnitTestingSupport.Services
{
    internal class DbMockAndInMemoryProvider<TDbContext> where TDbContext : DbContext
    {
        private Lazy<Mock<TDbContext>> _dbContextMockLazy;
        private Lazy<TDbContext> _dbInMemorySqliteLazy;
        private Lazy<TDbContext> _dbInMemoryInMemoryLazy;

        public Mock<TDbContext> DbContextMock
        {
            get
            {
                return _dbContextMockLazy.Value;
            }
        }

        public TDbContext DbInMemorySqlite
        {
            get
            {
                return _dbInMemorySqliteLazy.Value;
            }
        }

        public TDbContext DbInMemory
        {
            get
            {
                return _dbInMemoryInMemoryLazy.Value;
            }
        }

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
                .Options;

            var dbContext = (TDbContext)Activator.CreateInstance(typeof(TDbContext), dbContextSqliteOptions);
            dbContext.Database.EnsureCreated();

            return dbContext;
        }

        private TDbContext _initInMemoryInMemory()
        {
            var dbContextInMemoryOptions = new DbContextOptionsBuilder<TDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            var dbContext = (TDbContext)Activator.CreateInstance(typeof(TDbContext), dbContextInMemoryOptions);
            dbContext.Database.EnsureCreated();

            return dbContext;
        }
    }
}
