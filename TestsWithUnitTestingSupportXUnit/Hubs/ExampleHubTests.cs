using System.Linq;
using System.Threading.Tasks;
using ExampleSignalRCoreProject.Databases;
using ExampleSignalRCoreProject.Hubs;
using ExampleSignalRCoreProject.Hubs.Interfaces;
using ExampleSignalRCoreProject.Models;
using Moq;
using SignalR_UnitTestingSupportXUnit.Hubs;
using Xunit;

namespace TestsWithUnitTestingSupport.Hubs
{
    public class ExampleHubTests : HubUnitTestsWithEF<IExampleHubResponses, Db>
    {
        private ExampleHub _exampleHub;

        public ExampleHubTests() : base()
        {
            // Update 21.03.2021 - to be sure that tests are independent
            _exampleHub = null;
        }

        [Fact]
        public void TryGetDbContexMock_DbContextMockSuccesfullyTaken()
        {
            Assert.NotNull(DbContextMock.Object);
        }

        [Fact]
        public void TryGetDbInMemorySqlite_ClearDbInMemorySqliteSuccesfullyTaken()
        {
            Assert.True(!DbInMemorySqlite.Note.Any());
        }

        [Fact]
        public void TryGetDbInMemory_ClearDbInMemoryMockSuccesfullyTaken()
        {
            Assert.True(!DbInMemory.Note.Any());
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("StyleCop.CSharp.NamingRules", "SA1305:Field names should not use Hungarian notation", Justification = "This param is required here")]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Usage", "xUnit1026:Theory methods should use all of their parameters", Justification = "This param is required here")]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE0060:Remove unused parameter", Justification = "This param is required here")]
        public async Task TryGetDbInMemorySqlite_WeGetClearInstanceOfDbInEveryTest(bool iWantDoThisTest2Times)
        {
            Assert.True(!DbInMemorySqlite.Note.Any());

            DbInMemorySqlite.Note.Add(new Note { Content = "test content" });
            await DbInMemorySqlite.SaveChangesAsync();
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("StyleCop.CSharp.NamingRules", "SA1305:Field names should not use Hungarian notation", Justification = "This param is required here")]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Usage", "xUnit1026:Theory methods should use all of their parameters", Justification = "This param is required here")]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE0060:Remove unused parameter", Justification = "This param is required here")]
        public async Task TryGetDbInMemory_WeGetClearInstanceOfDbInEveryTest(bool iWantDoThisTest2Times)
        {
            Assert.True(!DbInMemory.Note.Any());

            DbInMemory.Note.Add(new Note { Content = "test content" });
            await DbInMemory.SaveChangesAsync();
        }

        [Fact]
        public async Task OnConnectedAsync_AllClientsNotifiedAboutSomethingElse()
        {
            _exampleHub = new ExampleHub(DbContextMock.Object);
            AssignToHubRequiredProperties(_exampleHub);

            await _exampleHub.OnConnectedAsync();

            ClientsAllMock.Verify(x => x.NotifyAboutSomethingElse(), Times.Once);
        }

        [Fact]
        public async Task NotifyAboutSomethingElseAllExcept_AllExceptNotifiedAsync()
        {
            _exampleHub = new ExampleHub(DbContextMock.Object);
            AssignToHubRequiredProperties(_exampleHub);

            await _exampleHub.NotifyAboutSomethingElseAllExcept();

            ClientsAllExceptMock.Verify(x => x.NotifyAboutSomethingElse(), Times.Once);
        }

        [Fact]
        public async Task NotifyCallerAboutSomethingElse_CallerNotifiedAsync()
        {
            _exampleHub = new ExampleHub(DbContextMock.Object);
            AssignToHubRequiredProperties(_exampleHub);

            await _exampleHub.NotifyCallerAboutSomethingElse();

            ClientsCallerMock.Verify(x => x.NotifyAboutSomethingElse(), Times.Once);
        }

        [Fact]
        public async Task NotifyClientAboutSomethingElse_ClientNotifiedAsync()
        {
            _exampleHub = new ExampleHub(DbContextMock.Object);
            AssignToHubRequiredProperties(_exampleHub);

            await _exampleHub.NotifyClientAboutSomethingElse();

            ClientsClientMock.Verify(x => x.NotifyAboutSomethingElse(), Times.Once);
        }

        [Fact]
        public async Task NotifyClientsAboutSomethingElse_ClientsNotifiedAsync()
        {
            _exampleHub = new ExampleHub(DbContextMock.Object);
            AssignToHubRequiredProperties(_exampleHub);

            await _exampleHub.NotifyClientsAboutSomethingElse();

            ClientsClientsMock.Verify(x => x.NotifyAboutSomethingElse(), Times.Once);
        }

        [Fact]
        public async Task NotifyGroupAboutSomethingElse_GroupNotifiedAsync()
        {
            _exampleHub = new ExampleHub(DbContextMock.Object);
            AssignToHubRequiredProperties(_exampleHub);

            await _exampleHub.NotifyGroupAboutSomethingElse();

            ClientsGroupMock.Verify(x => x.NotifyAboutSomethingElse(), Times.Once);
        }

        [Fact]
        public async Task NotifyGroupExceptAboutSomethingElse_GropuExceptNotifiedAsync()
        {
            _exampleHub = new ExampleHub(DbContextMock.Object);
            AssignToHubRequiredProperties(_exampleHub);

            await _exampleHub.NotifyGroupExceptAboutSomethingElse();

            ClientsGroupExceptMock.Verify(x => x.NotifyAboutSomethingElse(), Times.Once);
        }

        [Fact]
        public async Task NotifyGroupsAboutSomethingElse_GropusNotifiedAsync()
        {
            _exampleHub = new ExampleHub(DbContextMock.Object);
            AssignToHubRequiredProperties(_exampleHub);

            await _exampleHub.NotifyGroupsAboutSomethingElse();

            ClientsGroupsMock.Verify(x => x.NotifyAboutSomethingElse(), Times.Once);
        }

        [Fact]
        public async Task NotifyOthersAboutSomethingElse_OthersNotifiedAsync()
        {
            _exampleHub = new ExampleHub(DbContextMock.Object);
            AssignToHubRequiredProperties(_exampleHub);

            await _exampleHub.NotifyOthersAboutSomethingElse();

            ClientsOthersMock.Verify(x => x.NotifyAboutSomethingElse(), Times.Once);
        }

        [Fact]
        public async Task NotifyOthersInGroupAboutSomethingElse_OthersInGroupNotifiedAsync()
        {
            _exampleHub = new ExampleHub(DbContextMock.Object);
            AssignToHubRequiredProperties(_exampleHub);

            await _exampleHub.NotifyOthersInGroupAboutSomethingElse();

            ClientsOthersInGroupMock.Verify(x => x.NotifyAboutSomethingElse(), Times.Once);
        }

        [Fact]
        public async Task NotifyUserAboutSomethingElse_UserNotifiedAsync()
        {
            _exampleHub = new ExampleHub(DbContextMock.Object);
            AssignToHubRequiredProperties(_exampleHub);

            await _exampleHub.NotifyUserAboutSomethingElse();

            ClientsUserMock.Verify(x => x.NotifyAboutSomethingElse(), Times.Once);
        }

        [Fact]
        public async Task NotifyUsersAboutSomethingElse_UsersNotifiedAsync()
        {
            _exampleHub = new ExampleHub(DbContextMock.Object);
            AssignToHubRequiredProperties(_exampleHub);

            await _exampleHub.NotifyUsersAboutSomethingElse();

            ClientsUsersMock.Verify(x => x.NotifyAboutSomethingElse(), Times.Once);
        }

        [Fact]
        public void AddLoremAsKeyAndIpsumAsValueToContextItems_ContextContainThatKeyValuPair()
        {
            _exampleHub = new ExampleHub(DbContextMock.Object);
            AssignToHubRequiredProperties(_exampleHub);

            _exampleHub.AddLoremAsKeyAndIpsumAsValueToContextItems();

            VerifyContextItemsContainKeyValuePair("Lorem", "Ipsum");
        }

        [Fact]
        public async Task AddSomebodyToGroup_SomebodyAddedAsync()
        {
            _exampleHub = new ExampleHub(DbContextMock.Object);
            AssignToHubRequiredProperties(_exampleHub);

            await _exampleHub.AddSomebodyToGroup();

            VerifySomebodyAddedToGroup(Times.Once());
        }

        [Fact]
        public async Task RemoveSomebodyFromGroup_SomebodyRemovedAsync()
        {
            _exampleHub = new ExampleHub(DbContextMock.Object);
            AssignToHubRequiredProperties(_exampleHub);

            await _exampleHub.RemoveSomebodyFromGroup();

            VerifySomebodyRemovedFromGroup(Times.Once());
        }

        [Fact]
        public async Task AddNoteWithLoremIpsumAsContentToDb_dbProviderIsSqliteInMemory_NoteAdded()
        {
            _exampleHub = new ExampleHub(DbInMemorySqlite);
            AssignToHubRequiredProperties(_exampleHub);

            await _exampleHub.AddNoteWithLoremIpsumAsContentToDb();

            var noteFromDb = DbInMemorySqlite.Note.FirstOrDefault();
            Assert.NotNull(noteFromDb);
        }

        [Fact]
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