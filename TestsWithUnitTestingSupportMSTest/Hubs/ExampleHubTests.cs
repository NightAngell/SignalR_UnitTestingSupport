using System.Linq;
using System.Threading.Tasks;
using ExampleSignalRCoreProject.Databases;
using ExampleSignalRCoreProject.Hubs;
using ExampleSignalRCoreProject.Hubs.Interfaces;
using ExampleSignalRCoreProject.Models;
using Microsoft.AspNetCore.Routing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SignalR_UnitTestingSupportMSTest.Hubs;

namespace TestsWithUnitTestingSupport.Hubs
{
    [TestClass]
    public class ExampleHubTests : HubUnitTestsWithEF<IExampleHubResponses, Db>
    {
        private ExampleHub _exampleHub;

        [TestInitialize]
        public void SetUpExampleHubTests()
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
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE0060:Remove unused parameter", Justification = "Legacy")]
        public async Task TryGetDbInMemorySqlite_WeGetClearInstanceOfDbInEveryTest(string callThisTestTwoTimes)
        {
            Assert.IsTrue(!DbInMemorySqlite.Note.Any());

            DbInMemorySqlite.Note.Add(new Note { Content = "test content" });
            await DbInMemorySqlite.SaveChangesAsync();
        }

        [TestMethod]
        [DataRow("")]
        [DataRow("")]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE0060:Remove unused parameter", Justification = "Legacy")]
        public async Task TryGetDbInMemory_WeGetClearInstanceOfDbInEveryTest(string callThisTestTwoTimes)
        {
            Assert.IsTrue(!DbInMemory.Note.Any());

            DbInMemory.Note.Add(new Note { Content = "test content" });
            await DbInMemory.SaveChangesAsync();
        }

        [TestMethod]
        public async Task OnConnectedAsync_AllClientsNotifiedAboutSomethingElse()
        {
            _exampleHub = new ExampleHub(DbContextMock.Object);
            AssignToHubRequiredProperties(_exampleHub);

            await _exampleHub.OnConnectedAsync();

            ClientsAllMock.Verify(x => x.NotifyAboutSomethingElse(), Times.Once);
        }

        [TestMethod]
        public async Task NotifyAboutSomethingElseAllExcept_AllExceptNotifiedAsync()
        {
            _exampleHub = new ExampleHub(DbContextMock.Object);
            AssignToHubRequiredProperties(_exampleHub);

            await _exampleHub.NotifyAboutSomethingElseAllExcept();

            ClientsAllExceptMock.Verify(x => x.NotifyAboutSomethingElse(), Times.Once);
        }

        [TestMethod]
        public async Task NotifyCallerAboutSomethingElse_CallerNotifiedAsync()
        {
            _exampleHub = new ExampleHub(DbContextMock.Object);
            AssignToHubRequiredProperties(_exampleHub);

            await _exampleHub.NotifyCallerAboutSomethingElse();

            ClientsCallerMock.Verify(x => x.NotifyAboutSomethingElse(), Times.Once);
        }

        [TestMethod]
        public async Task NotifyClientAboutSomethingElse_ClientNotifiedAsync()
        {
            _exampleHub = new ExampleHub(DbContextMock.Object);
            AssignToHubRequiredProperties(_exampleHub);

            await _exampleHub.NotifyClientAboutSomethingElse();

            ClientsClientMock.Verify(x => x.NotifyAboutSomethingElse(), Times.Once);
        }

        [TestMethod]
        public async Task NotifyClientsAboutSomethingElse_ClientsNotifiedAsync()
        {
            _exampleHub = new ExampleHub(DbContextMock.Object);
            AssignToHubRequiredProperties(_exampleHub);

            await _exampleHub.NotifyClientsAboutSomethingElse();

            ClientsClientsMock.Verify(x => x.NotifyAboutSomethingElse(), Times.Once);
        }

        [TestMethod]
        public async Task NotifyGroupAboutSomethingElse_GroupNotifiedAsync()
        {
            _exampleHub = new ExampleHub(DbContextMock.Object);
            AssignToHubRequiredProperties(_exampleHub);

            await _exampleHub.NotifyGroupAboutSomethingElse();

            ClientsGroupMock.Verify(x => x.NotifyAboutSomethingElse(), Times.Once);
        }

        [TestMethod]
        public async Task NotifyGroupExceptAboutSomethingElse_GropuExceptNotifiedAsync()
        {
            _exampleHub = new ExampleHub(DbContextMock.Object);
            AssignToHubRequiredProperties(_exampleHub);

            await _exampleHub.NotifyGroupExceptAboutSomethingElse();

            ClientsGroupExceptMock.Verify(x => x.NotifyAboutSomethingElse(), Times.Once);
        }

        [TestMethod]
        public async Task NotifyGroupsAboutSomethingElse_GropusNotifiedAsync()
        {
            _exampleHub = new ExampleHub(DbContextMock.Object);
            AssignToHubRequiredProperties(_exampleHub);

            await _exampleHub.NotifyGroupsAboutSomethingElse();

            ClientsGroupsMock.Verify(x => x.NotifyAboutSomethingElse(), Times.Once);
        }

        [TestMethod]
        public async Task NotifyOthersAboutSomethingElse_OthersNotifiedAsync()
        {
            _exampleHub = new ExampleHub(DbContextMock.Object);
            AssignToHubRequiredProperties(_exampleHub);

            await _exampleHub.NotifyOthersAboutSomethingElse();

            ClientsOthersMock.Verify(x => x.NotifyAboutSomethingElse(), Times.Once);
        }

        [TestMethod]
        public async Task NotifyOthersInGroupAboutSomethingElse_OthersInGroupNotifiedAsync()
        {
            _exampleHub = new ExampleHub(DbContextMock.Object);
            AssignToHubRequiredProperties(_exampleHub);

            await _exampleHub.NotifyOthersInGroupAboutSomethingElse();

            ClientsOthersInGroupMock.Verify(x => x.NotifyAboutSomethingElse(), Times.Once);
        }

        [TestMethod]
        public async Task NotifyUserAboutSomethingElse_UserNotifiedAsync()
        {
            _exampleHub = new ExampleHub(DbContextMock.Object);
            AssignToHubRequiredProperties(_exampleHub);

            await _exampleHub.NotifyUserAboutSomethingElse();

            ClientsUserMock.Verify(x => x.NotifyAboutSomethingElse(), Times.Once);
        }

        [TestMethod]
        public async Task NotifyUsersAboutSomethingElse_UsersNotifiedAsync()
        {
            _exampleHub = new ExampleHub(DbContextMock.Object);
            AssignToHubRequiredProperties(_exampleHub);

            await _exampleHub.NotifyUsersAboutSomethingElse();

            ClientsUsersMock.Verify(x => x.NotifyAboutSomethingElse(), Times.Once);
        }

        [TestMethod]
        public void AddLoremAsKeyAndIpsumAsValueToContextItems_ContextContainThatKeyValuPairAsync()
        {
            _exampleHub = new ExampleHub(DbContextMock.Object);
            AssignToHubRequiredProperties(_exampleHub);

            _exampleHub.AddLoremAsKeyAndIpsumAsValueToContextItems();

            VerifyContextItemsContainKeyValuePair("Lorem", "Ipsum");
        }

        [TestMethod]
        public async Task AddSomebodyToGroup_SomebodyAddedAsync()
        {
            _exampleHub = new ExampleHub(DbContextMock.Object);
            AssignToHubRequiredProperties(_exampleHub);

            await _exampleHub.AddSomebodyToGroup();

            VerifySomebodyAddedToGroup(Times.Once());
        }

        [TestMethod]
        public async Task RemoveSomebodyFromGroup_SomebodyRemovedAsync()
        {
            _exampleHub = new ExampleHub(DbContextMock.Object);
            AssignToHubRequiredProperties(_exampleHub);

            await _exampleHub.RemoveSomebodyFromGroup();

            VerifySomebodyRemovedFromGroup(Times.Once());
        }

        [TestMethod]
        public async Task AddNoteWithLoremIpsumAsContentToDb_dbProviderIsSqliteInMemory_NoteAdded()
        {
            _exampleHub = new ExampleHub(DbInMemorySqlite);
            AssignToHubRequiredProperties(_exampleHub);

            await _exampleHub.AddNoteWithLoremIpsumAsContentToDb();

            var noteFromDb = DbInMemorySqlite.Note.FirstOrDefault();
            Assert.IsNotNull(noteFromDb);
        }

        [TestMethod]
        public async Task AddNoteWithLoremIpsumAsContentToDb_dbProviderIsInMemory_NoteAdded()
        {
            _exampleHub = new ExampleHub(DbInMemory);
            AssignToHubRequiredProperties(_exampleHub);

            await _exampleHub.AddNoteWithLoremIpsumAsContentToDb();

            var noteFromDb = DbInMemory.Note.FirstOrDefault();
            Assert.IsNotNull(noteFromDb);
        }

        [TestMethod]
        public async Task GetMessageFromClient_MessageReceived()
        {
            _exampleHub = new ExampleHub(DbInMemory);
            AssignToHubRequiredProperties(_exampleHub);

            var expectedMessage = "Pizza!";
            ClientsClientMock
                .Setup(x => x.GetMessage())
                .Returns(Task.FromResult(expectedMessage));

            var message = await _exampleHub.GetMessageFromClient();

            Assert.AreEqual(expectedMessage, message);
        }
    }
}
