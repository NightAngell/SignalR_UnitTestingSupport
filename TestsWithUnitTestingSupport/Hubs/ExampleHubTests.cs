using System.Linq;
using System.Threading.Tasks;
using ExampleSignalRCoreProject.Databases;
using ExampleSignalRCoreProject.Hubs;
using ExampleSignalRCoreProject.Hubs.Interfaces;
using ExampleSignalRCoreProject.Models;
using Moq;
using NUnit.Framework;
using SignalR_UnitTestingSupport.Hubs;

namespace TestsWithUnitTestingSupport.Hubs
{
    [TestFixture]
    public class ExampleHubTests : HubUnitTestsWithEF<IExampleHubResponses, Db>
    {
        private ExampleHub _exampleHub;
        
        [SetUp]
        public void SetUpExampleHubTests()
        {
            // Update 21.03.2021 - to be sure that tests are independent
            _exampleHub = null;
        }

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
        public async Task OnConnectedAsync_AllClientsNotifiedAboutSomethingElse()
        {
            _exampleHub = new ExampleHub(DbContextMock.Object);
            AssignToHubRequiredProperties(_exampleHub);

            await _exampleHub.OnConnectedAsync();

            ClientsAllMock.Verify(x => x.NotifyAboutSomethingElse(), Times.Once);
        }

        [Test]
        public async Task NotifyAboutSomethingElseAllExcept_AllExceptNotified()
        {
            _exampleHub = new ExampleHub(DbContextMock.Object);
            AssignToHubRequiredProperties(_exampleHub);

            await _exampleHub.NotifyAboutSomethingElseAllExcept();

            ClientsAllExceptMock.Verify(x => x.NotifyAboutSomethingElse(), Times.Once);
        }

        [Test]
        public async Task NotifyCallerAboutSomethingElse_CallerNotifiedAsync()
        {
            _exampleHub = new ExampleHub(DbContextMock.Object);
            AssignToHubRequiredProperties(_exampleHub);

            await _exampleHub.NotifyCallerAboutSomethingElse();

            ClientsCallerMock.Verify(x => x.NotifyAboutSomethingElse(), Times.Once);
        }

        [Test]
        public async Task NotifyClientAboutSomethingElse_ClientNotifiedAsync()
        {
            _exampleHub = new ExampleHub(DbContextMock.Object);
            AssignToHubRequiredProperties(_exampleHub);

            await _exampleHub.NotifyClientAboutSomethingElse();

            ClientsClientMock.Verify(x => x.NotifyAboutSomethingElse(), Times.Once);
        }

        [Test]
        public async Task NotifyClientsAboutSomethingElse_ClientsNotifiedAsync()
        {
            _exampleHub = new ExampleHub(DbContextMock.Object);
            AssignToHubRequiredProperties(_exampleHub);

            await _exampleHub.NotifyClientsAboutSomethingElse();

            ClientsClientsMock.Verify(x => x.NotifyAboutSomethingElse(), Times.Once);
        }

        [Test]
        public async Task NotifyGroupAboutSomethingElse_GroupNotifiedAsync()
        {
            _exampleHub = new ExampleHub(DbContextMock.Object);
            AssignToHubRequiredProperties(_exampleHub);

            await _exampleHub.NotifyGroupAboutSomethingElse();

            ClientsGroupMock.Verify(x => x.NotifyAboutSomethingElse(), Times.Once);
        }

        [Test]
        public async Task NotifyGroupExceptAboutSomethingElse_GropuExceptNotifiedAsync()
        {
            _exampleHub = new ExampleHub(DbContextMock.Object);
            AssignToHubRequiredProperties(_exampleHub);

            await _exampleHub.NotifyGroupExceptAboutSomethingElse();

            ClientsGroupExceptMock.Verify(x => x.NotifyAboutSomethingElse(), Times.Once);
        }

        [Test]
        public async Task NotifyGroupsAboutSomethingElse_GropusNotifiedAsync()
        {
            _exampleHub = new ExampleHub(DbContextMock.Object);
            AssignToHubRequiredProperties(_exampleHub);

            await _exampleHub.NotifyGroupsAboutSomethingElse();

            ClientsGroupsMock.Verify(x => x.NotifyAboutSomethingElse(), Times.Once);
        }

        [Test]
        public async Task NotifyOthersAboutSomethingElse_OthersNotifiedAsync()
        {
            _exampleHub = new ExampleHub(DbContextMock.Object);
            AssignToHubRequiredProperties(_exampleHub);

            await _exampleHub.NotifyOthersAboutSomethingElse();

            ClientsOthersMock.Verify(x => x.NotifyAboutSomethingElse(), Times.Once);
        }

        [Test]
        public async Task NotifyOthersInGroupAboutSomethingElse_OthersInGroupNotifiedAsync()
        {
            _exampleHub = new ExampleHub(DbContextMock.Object);
            AssignToHubRequiredProperties(_exampleHub);

            await _exampleHub.NotifyOthersInGroupAboutSomethingElse();

            ClientsOthersInGroupMock.Verify(x => x.NotifyAboutSomethingElse(), Times.Once);
        }

        [Test]
        public async Task NotifyUserAboutSomethingElse_UserNotifiedAsync()
        {
            _exampleHub = new ExampleHub(DbContextMock.Object);
            AssignToHubRequiredProperties(_exampleHub);

            await _exampleHub.NotifyUserAboutSomethingElse();

            ClientsUserMock.Verify(x => x.NotifyAboutSomethingElse(), Times.Once);
        }

        [Test]
        public async Task NotifyUsersAboutSomethingElse_UsersNotifiedAsync()
        {
            _exampleHub = new ExampleHub(DbContextMock.Object);
            AssignToHubRequiredProperties(_exampleHub);

            await _exampleHub.NotifyUsersAboutSomethingElse();

            ClientsUsersMock.Verify(x => x.NotifyAboutSomethingElse(), Times.Once);
        }

        [Test]
        public void AddLoremAsKeyAndIpsumAsValueToContextItems_ContextContainThatKeyValuPair()
        {
            _exampleHub = new ExampleHub(DbContextMock.Object);
            AssignToHubRequiredProperties(_exampleHub);

            _exampleHub.AddLoremAsKeyAndIpsumAsValueToContextItems();

            VerifyContextItemsContainKeyValuePair("Lorem", "Ipsum");
        }

        [Test]
        public async Task AddSomebodyToGroup_SomebodyAddedAsync()
        {
            _exampleHub = new ExampleHub(DbContextMock.Object);
            AssignToHubRequiredProperties(_exampleHub);

            await _exampleHub.AddSomebodyToGroup();

            VerifySomebodyAddedToGroup(Times.Once());
        }

        [Test]
        public async Task RemoveSomebodyFromGroup_SomebodyRemovedAsync()
        {
            _exampleHub = new ExampleHub(DbContextMock.Object);
            AssignToHubRequiredProperties(_exampleHub);

            await _exampleHub.RemoveSomebodyFromGroup();

            VerifySomebodyRemovedFromGroup(Times.Once());
        }

        [Test]
        public async Task AddNoteWithLoremIpsumAsContentToDb_dbProviderIsSqliteInMemory_NoteAdded()
        {
            _exampleHub = new ExampleHub(DbInMemorySqlite);
            AssignToHubRequiredProperties(_exampleHub);

            await _exampleHub.AddNoteWithLoremIpsumAsContentToDb();

            var noteFromDb = DbInMemorySqlite.Note.FirstOrDefault();
            Assert.NotNull(noteFromDb);
        }

        [Test]
        public async Task AddNoteWithLoremIpsumAsContentToDb_dbProviderIsInMemory_NoteAdded()
        {
            _exampleHub = new ExampleHub(DbInMemory);
            AssignToHubRequiredProperties(_exampleHub);

            await _exampleHub.AddNoteWithLoremIpsumAsContentToDb();

            var noteFromDb = DbInMemory.Note.FirstOrDefault();
            Assert.NotNull(noteFromDb);
        }
    }
}
