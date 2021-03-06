﻿using System.Linq;
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
        public void NotifyAboutSomethingElseAllExcept_AllExceptNotified()
        {
            _exampleHub = new ExampleHub(DbContextMock.Object);
            AssignToHubRequiredProperties(_exampleHub);

            _exampleHub.NotifyAboutSomethingElseAllExcept();

            ClientsAllExceptMock.Verify(x => x.NotifyAboutSomethingElse(), Times.Once);
        }

        [Fact]
        public void NotifyCallerAboutSomethingElse_CallerNotified()
        {
            _exampleHub = new ExampleHub(DbContextMock.Object);
            AssignToHubRequiredProperties(_exampleHub);

            _exampleHub.NotifyCallerAboutSomethingElse();

            ClientsCallerMock.Verify(x => x.NotifyAboutSomethingElse(), Times.Once);
        }

        [Fact]
        public void NotifyClientAboutSomethingElse_ClientNotified()
        {
            _exampleHub = new ExampleHub(DbContextMock.Object);
            AssignToHubRequiredProperties(_exampleHub);

            _exampleHub.NotifyClientAboutSomethingElse();

            ClientsClientMock.Verify(x => x.NotifyAboutSomethingElse(), Times.Once);
        }

        [Fact]
        public void NotifyClientsAboutSomethingElse_ClientsNotified()
        {
            _exampleHub = new ExampleHub(DbContextMock.Object);
            AssignToHubRequiredProperties(_exampleHub);

            _exampleHub.NotifyClientsAboutSomethingElse();

            ClientsClientsMock.Verify(x => x.NotifyAboutSomethingElse(), Times.Once);
        }

        [Fact]
        public void NotifyGroupAboutSomethingElse_GroupNotified()
        {
            _exampleHub = new ExampleHub(DbContextMock.Object);
            AssignToHubRequiredProperties(_exampleHub);

            _exampleHub.NotifyGroupAboutSomethingElse();

            ClientsGroupMock.Verify(x => x.NotifyAboutSomethingElse(), Times.Once);
        }

        [Fact]
        public void NotifyGroupExceptAboutSomethingElse_GropuExceptNotified()
        {
            _exampleHub = new ExampleHub(DbContextMock.Object);
            AssignToHubRequiredProperties(_exampleHub);

            _exampleHub.NotifyGroupExceptAboutSomethingElse();

            ClientsGroupExceptMock.Verify(x => x.NotifyAboutSomethingElse(), Times.Once);
        }

        [Fact]
        public void NotifyGroupsAboutSomethingElse_GropusNotified()
        {
            _exampleHub = new ExampleHub(DbContextMock.Object);
            AssignToHubRequiredProperties(_exampleHub);

            _exampleHub.NotifyGroupsAboutSomethingElse();

            ClientsGroupsMock.Verify(x => x.NotifyAboutSomethingElse(), Times.Once);
        }

        [Fact]
        public void NotifyOthersAboutSomethingElse_OthersNotified()
        {
            _exampleHub = new ExampleHub(DbContextMock.Object);
            AssignToHubRequiredProperties(_exampleHub);

            _exampleHub.NotifyOthersAboutSomethingElse();

            ClientsOthersMock.Verify(x => x.NotifyAboutSomethingElse(), Times.Once);
        }

        [Fact]
        public void NotifyOthersInGroupAboutSomethingElse_OthersInGroupNotified()
        {
            _exampleHub = new ExampleHub(DbContextMock.Object);
            AssignToHubRequiredProperties(_exampleHub);

            _exampleHub.NotifyOthersInGroupAboutSomethingElse();

            ClientsOthersInGroupMock.Verify(x => x.NotifyAboutSomethingElse(), Times.Once);
        }

        [Fact]
        public void NotifyUserAboutSomethingElse_UserNotified()
        {
            _exampleHub = new ExampleHub(DbContextMock.Object);
            AssignToHubRequiredProperties(_exampleHub);

            _exampleHub.NotifyUserAboutSomethingElse();

            ClientsUserMock.Verify(x => x.NotifyAboutSomethingElse(), Times.Once);
        }

        [Fact]
        public void NotifyUsersAboutSomethingElse_UsersNotified()
        {
            _exampleHub = new ExampleHub(DbContextMock.Object);
            AssignToHubRequiredProperties(_exampleHub);

            _exampleHub.NotifyUsersAboutSomethingElse();

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
        public void AddSomebodyToGroup_SomebodyAdded()
        {
            _exampleHub = new ExampleHub(DbContextMock.Object);
            AssignToHubRequiredProperties(_exampleHub);

            _exampleHub.AddSomebodyToGroup();

            VerifySomebodyAddedToGroup(Times.Once());
        }

        [Fact]
        public void RemoveSomebodyFromGroup_SomebodyRemoved()
        {
            _exampleHub = new ExampleHub(DbContextMock.Object);
            AssignToHubRequiredProperties(_exampleHub);

            _exampleHub.RemoveSomebodyFromGroup();

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