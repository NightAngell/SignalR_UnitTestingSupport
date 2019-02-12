using ExampleSignalRCoreProject.Databases;
using ExampleSignalRCoreProject.Hubs;
using Microsoft.AspNetCore.SignalR;
using Moq;
using NUnit.Framework;
using SignalR_UnitTestingSupport.Hubs;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using ExampleSignalRCoreProject.Models;

namespace TestsWithUnitTestingSupport.Hubs
{
    [TestFixture]
    class ExampleNonGenericHubTests : HubUnitTestsWithEF<Db>
    {
        ExampleNonGenericHub _exampleHub;

        [Test]
        public void TryGetDbContexMock_DbContextMockSuccesfullyTaken()
        {
            Assert.NotNull(DbContextMock.Object);
        }

        [Test]
        public void TryGetDbInMemorySqlite_ClearDbInMemorySqliteSuccesfullyTaken()
        {
            Assert.Zero(DbInMemorySqlite.Note.Count());
        }

        [Test]
        public void TryGetDbInMemory_ClearDbInMemoryMockSuccesfullyTaken()
        {
            Assert.Zero(DbInMemory.Note.Count());
        }

        [Test]
        [TestCase]
        [TestCase]
        public async Task TryGetDbInMemorySqlite_WeGetClearInstanceOfDbInEveryTest()
        {
            Assert.IsTrue(DbInMemorySqlite.Note.Count() == 0);

            DbInMemorySqlite.Note.Add(new Note { Content = "test content" });
            await DbInMemorySqlite.SaveChangesAsync();
        }

        [Test]
        [TestCase]
        [TestCase]
        public async Task TryGetDbInMemory_WeGetClearInstanceOfDbInEveryTest()
        {
            Assert.IsTrue(DbInMemory.Note.Count() == 0);

            DbInMemory.Note.Add(new Note { Content = "test content" });
            await DbInMemory.SaveChangesAsync();
        }

        [Test]
        public async Task NotifyAllAboutSomething_AllNotifiedAboutSomething()
        {
            _exampleHub = new ExampleNonGenericHub();
            AssignToHubRequiredProperties(_exampleHub);

            await _exampleHub.NotifyAllAboutSomething();

            ClientsAllMock
                .Verify(x => x.SendCoreAsync("NotifyUserAboutSomething", new object[] { }, It.IsAny<CancellationToken>()));
        }

        [Test]
        public async Task NotifyAllExceptAboutSomething_AllExceptNotifiedAboutSomething()
        {
            _exampleHub = new ExampleNonGenericHub();
            AssignToHubRequiredProperties(_exampleHub);

            await _exampleHub.NotifyAllExceptAboutSomething();

            ClientsAllExceptMock
                .Verify(x => x.SendCoreAsync("NotifyUserAboutSomething", new object[] { }, It.IsAny<CancellationToken>()));
        }

        [Test]
        public async Task NotifyCallerAboutSomething_CallerNotifiedAboutSomething()
        {
            _exampleHub = new ExampleNonGenericHub();
            AssignToHubRequiredProperties(_exampleHub);

            await _exampleHub.NotifyCallerAboutSomething();

            ClientsCallerMock
                .Verify(x => x.SendCoreAsync("NotifyUserAboutSomething", new object[] { }, It.IsAny<CancellationToken>()));
        }

        [Test]
        public async Task NotifyClientAboutSomething_ClientNotifiedAboutSomething()
        {
            _exampleHub = new ExampleNonGenericHub();
            AssignToHubRequiredProperties(_exampleHub);

            await _exampleHub.NotifyClientAboutSomething();

            ClientsClientMock
                .Verify(x => x.SendCoreAsync("NotifyUserAboutSomething", new object[] { }, It.IsAny<CancellationToken>()));
        }

        [Test]
        public async Task NotifyClientsAboutSomething_ClientsNotifiedAboutSomething()
        {
            _exampleHub = new ExampleNonGenericHub();
            AssignToHubRequiredProperties(_exampleHub);

            await _exampleHub.NotifyClientsAboutSomething();

            ClientsClientsMock
                .Verify(x => x.SendCoreAsync("NotifyUserAboutSomething", new object[] { }, It.IsAny<CancellationToken>()));
        }

        [Test]
        public async Task NotifyGroupAboutSomething_GroupNotifiedAboutSomething()
        {
            _exampleHub = new ExampleNonGenericHub();
            AssignToHubRequiredProperties(_exampleHub);

            await _exampleHub.NotifyGrgoupAboutSomething();

            ClientsGroupMock
                .Verify(x => x.SendCoreAsync("NotifyUserAboutSomething", new object[] { }, It.IsAny<CancellationToken>()));
        }

        [Test]
        public async Task NotifyGroupExceptAboutSomething_GroupExceptNotifiedAboutSomething()
        {
            _exampleHub = new ExampleNonGenericHub();
            AssignToHubRequiredProperties(_exampleHub);

            await _exampleHub.NotifyGrgoupExceptAboutSomething();

            ClientsGroupExceptMock
                .Verify(x => x.SendCoreAsync("NotifyUserAboutSomething", new object[] { }, It.IsAny<CancellationToken>()));
        }

        [Test]
        public async Task NotifyGroupsAboutSomething_GroupsNotifiedAboutSomething()
        {
            _exampleHub = new ExampleNonGenericHub();
            AssignToHubRequiredProperties(_exampleHub);

            await _exampleHub.NotifyGroupsAboutSomething();

            ClientsGroupsMock
                .Verify(x => x.SendCoreAsync("NotifyUserAboutSomething", new object[] { }, It.IsAny<CancellationToken>()));
        }

        [Test]
        public async Task NotifyOthersAboutSomething_OthersAboutNotifiedSomething()
        {
            _exampleHub = new ExampleNonGenericHub();
            AssignToHubRequiredProperties(_exampleHub);

            await _exampleHub.NotifyOthersAboutSomething();

            ClientsOthersMock
                .Verify(x => x.SendCoreAsync("NotifyUserAboutSomething", new object[] { }, It.IsAny<CancellationToken>()));
        }

        [Test]
        public async Task NotifyOthersInGroupAboutSomething_OthersInGroupNotifiedAboutSomething()
        {
            _exampleHub = new ExampleNonGenericHub();
            AssignToHubRequiredProperties(_exampleHub);

            await _exampleHub.NotifyOthersInGroupAboutSomething();

            ClientsOthersInGroupMock
                .Verify(x => x.SendCoreAsync("NotifyUserAboutSomething", new object[] { }, It.IsAny<CancellationToken>()));
        }

        [Test]
        public async Task NotifyUserAboutSomething_UserNotifiedAboutSomething()
        {
            _exampleHub = new ExampleNonGenericHub();
            AssignToHubRequiredProperties(_exampleHub);

            await _exampleHub.NotifyUserAboutSomething();

            ClientsUserMock
                .Verify(x => x.SendCoreAsync("NotifyUserAboutSomething", new object[] { }, It.IsAny<CancellationToken>()));
        }

        [Test]
        public async Task NotifyUsersAboutSomething_UsersNotifiedAboutSomething()
        {
            _exampleHub = new ExampleNonGenericHub();
            AssignToHubRequiredProperties(_exampleHub);

            await _exampleHub.NotifyUsersAboutSomething();

            ClientsUsersMock
                .Verify(x => x.SendCoreAsync("NotifyUserAboutSomething", new object[] { }, It.IsAny<CancellationToken>()));
        }
    }
}
