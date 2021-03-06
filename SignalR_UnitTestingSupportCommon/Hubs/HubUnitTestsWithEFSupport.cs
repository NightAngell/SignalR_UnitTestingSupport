﻿using Microsoft.EntityFrameworkCore;
using Moq;
using SignalR_UnitTestingSupportCommon.EFSupport;
using SignalR_UnitTestingSupportCommon.Interfaces;

namespace SignalR_UnitTestingSupportCommon.Hubs
{
    /// <summary>
    /// Base class which provide support for testing hub with EntityFramework Core (But without auto SetUp by any test engine)
    /// </summary>
    /// <typeparam name="TDbContext">DbContext child or DbContext itself</typeparam>
    public class HubUnitTestsWithEFSupport<TDbContext> : HubUnitTestsSupport, IHubUnitTestsWithEF<TDbContext>
        where TDbContext : DbContext
    {
        private readonly DbMockAndInMemoryProvider<TDbContext> _dbProvider = new DbMockAndInMemoryProvider<TDbContext>();

        /// <summary>
        /// Gets by default, pure TDbContext mock, without any setup.
        /// </summary>
        public Mock<TDbContext> DbContextMock
        {
            get
            {
                return _dbProvider.DbContextMock;
            }
        }

        /// <summary>
        /// Gets relational database in memory
        /// </summary>
        public TDbContext DbInMemorySqlite
        {
            get
            {
                return _dbProvider.DbInMemorySqlite;
            }
        }

        /// <summary>
        /// Gets database in memory (not really relational)
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
