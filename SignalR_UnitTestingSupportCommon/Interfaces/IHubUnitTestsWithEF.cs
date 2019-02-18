using Microsoft.EntityFrameworkCore;
using Moq;

namespace SignalR_UnitTestingSupport.Hubs
{
    /// <summary>
    /// To be sure we implement all features for testing pure Hub (or Hub<T>) plus entity framework core
    /// </summary>
    public interface IHubUnitTestsWithEF<TDbContext> where TDbContext : DbContext
    {
        Mock<TDbContext> DbContextMock { get; }
        TDbContext DbInMemory { get; }
        TDbContext DbInMemorySqlite { get; }

        void EfSetUp();
        void TearDownEFContexts();
    }
}