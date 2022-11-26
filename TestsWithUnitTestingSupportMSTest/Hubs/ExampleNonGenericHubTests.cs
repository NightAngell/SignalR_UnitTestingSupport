using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ExampleSignalRCoreProject.Databases;
using ExampleSignalRCoreProject.Hubs;
using ExampleSignalRCoreProject.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SignalR_UnitTestingSupportMSTest.Hubs;

namespace TestsWithUnitTestingSupport.Hubs
{
    [TestClass]
    public class ExampleNonGenericHubTests : HubUnitTestsWithEF<Db>
    {
        private ExampleNonGenericHub _exampleHub;

        [TestInitialize]
        public void SetUpExampleNonGenericHubTests()
        {
            // Update 21.03.2021 - to be sure that tests are independent
            _exampleHub = null;
        }

        [TestMethod]
        public void TryGetDbContexMock_DbContextMockSuccesfullyTaken()
        {
            Assert.IsNotNull(DbContextMock.Object);
        }

        [TestMethod]
        public void TryGetDbInMemorySqlite_ClearDbInMemorySqliteSuccesfullyTaken()
        {
            Assert.AreEqual(DbInMemorySqlite.Note.Count(), 0);
        }

        [TestMethod]
        public void TryGetDbInMemory_ClearDbInMemoryMockSuccesfullyTaken()
        {
            Assert.AreEqual(DbInMemory.Note.Count(), 0);
        }

        [TestMethod]
        [DataRow("")]
        [DataRow("")]
        public async Task TryGetDbInMemorySqlite_WeGetClearInstanceOfDbInEveryTest(string callThisTestTwoTimes)
        {
            Assert.IsTrue(!DbInMemorySqlite.Note.Any());

            DbInMemorySqlite.Note.Add(new Note { Content = "test content" });
            await DbInMemorySqlite.SaveChangesAsync();
        }

        [TestMethod]
        [DataRow("")]
        [DataRow("")]
        public async Task TryGetDbInMemory_WeGetClearInstanceOfDbInEveryTest(string callThisTestTwoTimes)
        {
            Assert.IsTrue(!DbInMemory.Note.Any());

            DbInMemory.Note.Add(new Note { Content = "test content" });
            await DbInMemory.SaveChangesAsync();
        }

        [TestMethod]
        public async Task NotifyAllAboutSomething_AllNotifiedAboutSomething()
        {
            _exampleHub = new ExampleNonGenericHub();
            AssignToHubRequiredProperties(_exampleHub);

            await _exampleHub.NotifyAllAboutSomething();

            ClientsAllMock
                .Verify(x => x.SendCoreAsync("NotifyUserAboutSomething", System.Array.Empty<object>(), It.IsAny<CancellationToken>()));
        }

        [TestMethod]
        public async Task NotifyAllExceptAboutSomething_AllExceptNotifiedAboutSomething()
        {
            _exampleHub = new ExampleNonGenericHub();
            AssignToHubRequiredProperties(_exampleHub);

            await _exampleHub.NotifyAllExceptAboutSomething();

            ClientsAllExceptMock
                .Verify(x => x.SendCoreAsync("NotifyUserAboutSomething", System.Array.Empty<object>(), It.IsAny<CancellationToken>()));
        }

        [TestMethod]
        public async Task NotifyCallerAboutSomething_CallerNotifiedAboutSomething()
        {
            _exampleHub = new ExampleNonGenericHub();
            AssignToHubRequiredProperties(_exampleHub);

            await _exampleHub.NotifyCallerAboutSomething();

            ClientsCallerMock
                .Verify(x => x.SendCoreAsync("NotifyUserAboutSomething", System.Array.Empty<object>(), It.IsAny<CancellationToken>()));
        }

        [TestMethod]
        public async Task NotifyClientAboutSomething_ClientNotifiedAboutSomething()
        {
            _exampleHub = new ExampleNonGenericHub();
            AssignToHubRequiredProperties(_exampleHub);

            await _exampleHub.NotifyClientAboutSomething();

            ClientsClientMock
                .Verify(x => x.SendCoreAsync("NotifyUserAboutSomething", System.Array.Empty<object>(), It.IsAny<CancellationToken>()));
        }

        [TestMethod]
        public async Task NotifyClientsAboutSomething_ClientsNotifiedAboutSomething()
        {
            _exampleHub = new ExampleNonGenericHub();
            AssignToHubRequiredProperties(_exampleHub);

            await _exampleHub.NotifyClientsAboutSomething();

            ClientsClientsMock
                .Verify(x => x.SendCoreAsync("NotifyUserAboutSomething", System.Array.Empty<object>(), It.IsAny<CancellationToken>()));
        }

        [TestMethod]
        public async Task NotifyGroupAboutSomething_GroupNotifiedAboutSomething()
        {
            _exampleHub = new ExampleNonGenericHub();
            AssignToHubRequiredProperties(_exampleHub);

            await _exampleHub.NotifyGrgoupAboutSomething();

            ClientsGroupMock
                .Verify(x => x.SendCoreAsync("NotifyUserAboutSomething", System.Array.Empty<object>(), It.IsAny<CancellationToken>()));
        }

        [TestMethod]
        public async Task NotifyGroupExceptAboutSomething_GroupExceptNotifiedAboutSomething()
        {
            _exampleHub = new ExampleNonGenericHub();
            AssignToHubRequiredProperties(_exampleHub);

            await _exampleHub.NotifyGrgoupExceptAboutSomething();

            ClientsGroupExceptMock
                .Verify(x => x.SendCoreAsync("NotifyUserAboutSomething", System.Array.Empty<object>(), It.IsAny<CancellationToken>()));
        }

        [TestMethod]
        public async Task NotifyGroupsAboutSomething_GroupsNotifiedAboutSomething()
        {
            _exampleHub = new ExampleNonGenericHub();
            AssignToHubRequiredProperties(_exampleHub);

            await _exampleHub.NotifyGroupsAboutSomething();

            ClientsGroupsMock
                .Verify(x => x.SendCoreAsync("NotifyUserAboutSomething", System.Array.Empty<object>(), It.IsAny<CancellationToken>()));
        }

        [TestMethod]
        public async Task NotifyOthersAboutSomething_OthersAboutNotifiedSomething()
        {
            _exampleHub = new ExampleNonGenericHub();
            AssignToHubRequiredProperties(_exampleHub);

            await _exampleHub.NotifyOthersAboutSomething();

            ClientsOthersMock
                .Verify(x => x.SendCoreAsync("NotifyUserAboutSomething", System.Array.Empty<object>(), It.IsAny<CancellationToken>()));
        }

        [TestMethod]
        public async Task NotifyOthersInGroupAboutSomething_OthersInGroupNotifiedAboutSomething()
        {
            _exampleHub = new ExampleNonGenericHub();
            AssignToHubRequiredProperties(_exampleHub);

            await _exampleHub.NotifyOthersInGroupAboutSomething();

            ClientsOthersInGroupMock
                .Verify(x => x.SendCoreAsync("NotifyUserAboutSomething", System.Array.Empty<object>(), It.IsAny<CancellationToken>()));
        }

        [TestMethod]
        public async Task NotifyUserAboutSomething_UserNotifiedAboutSomething()
        {
            _exampleHub = new ExampleNonGenericHub();
            AssignToHubRequiredProperties(_exampleHub);

            await _exampleHub.NotifyUserAboutSomething();

            ClientsUserMock
                .Verify(x => x.SendCoreAsync("NotifyUserAboutSomething", System.Array.Empty<object>(), It.IsAny<CancellationToken>()));
        }

        [TestMethod]
        public async Task NotifyUsersAboutSomething_UsersNotifiedAboutSomething()
        {
            _exampleHub = new ExampleNonGenericHub();
            AssignToHubRequiredProperties(_exampleHub);

            await _exampleHub.NotifyUsersAboutSomething();

            ClientsUsersMock
                .Verify(x => x.SendCoreAsync("NotifyUserAboutSomething", System.Array.Empty<object>(), It.IsAny<CancellationToken>()));
        }

        [TestMethod]
        public async Task GetMessageFromClient_MessageReceived()
        {
            _exampleHub = new ExampleNonGenericHub();
            AssignToHubRequiredProperties(_exampleHub);

            var expectedMessage = "Pizza!";
            ClientsClientMock
                .Setup(x => x.InvokeCoreAsync<string>(
                    ExampleNonGenericHub.GetMessageInvoke,
                    Array.Empty<object>(),
                    It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult(expectedMessage));

            var message = await _exampleHub.GetMessageFromClient();

            Assert.AreEqual(expectedMessage, message);
        }
    }
}
