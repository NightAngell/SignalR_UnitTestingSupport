using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ExampleSignalRCoreProject.Databases;
using ExampleSignalRCoreProject.Hubs;
using ExampleSignalRCoreProject.Hubs.Interfaces;
using ExampleSignalRCoreProject.Models;
using Moq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.EntityFrameworkCore;
using SignalR_UnitTestingSupport.Hubs;
using System.Linq;

namespace TestsWithUnitTestingSupport.Hubs
{
    [TestClass]
    public class ExampleHubTests : HubUnitTestsWithEF<ExampleHubResponses, Db>
    {
        ExampleHub _exampleHub;

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
            Assert.IsTrue(DbInMemorySqlite.Note.Count() == 0);

            DbInMemorySqlite.Note.Add(new Note { Content = "test content" });
            await DbInMemorySqlite.SaveChangesAsync();
        }

        [TestMethod]
        [DataRow("")]
        [DataRow("")]
        public async Task TryGetDbInMemory_WeGetClearInstanceOfDbInEveryTest(string callThisTestTwoTimes)
        {
            Assert.IsTrue(DbInMemory.Note.Count() == 0);

            DbInMemory.Note.Add(new Note { Content = "test content" });
            await DbInMemory.SaveChangesAsync();
        }

        [TestMethod]
        public async Task OnConnectedAsync_AllClientsNotifiedAboutSomethingElse()
        {
            _exampleHub = new ExampleHub(DbContextMock.Object);
            AssignToHubRequiredProperties(_exampleHub);

            await  _exampleHub.OnConnectedAsync();

            ClientsAllMock.Verify(x => x.NotifyAboutSomethingElse(), Times.Once);
        }

        [TestMethod]
        public void NotifyAboutSomethingElseAllExcept_AllExceptNotified()
        {
            _exampleHub = new ExampleHub(DbContextMock.Object);
            AssignToHubRequiredProperties(_exampleHub);

            _exampleHub.NotifyAboutSomethingElseAllExcept();

            ClientsAllExceptMock.Verify(x => x.NotifyAboutSomethingElse(), Times.Once);
        }

        [TestMethod]
        public void NotifyCallerAboutSomethingElse_CallerNotified()
        {
            _exampleHub = new ExampleHub(DbContextMock.Object);
            AssignToHubRequiredProperties(_exampleHub);

            _exampleHub.NotifyCallerAboutSomethingElse();

            ClientsCallerMock.Verify(x => x.NotifyAboutSomethingElse(), Times.Once);
        }

        [TestMethod]
        public void NotifyClientAboutSomethingElse_ClientNotified()
        {
            _exampleHub = new ExampleHub(DbContextMock.Object);
            AssignToHubRequiredProperties(_exampleHub);

            _exampleHub.NotifyClientAboutSomethingElse();

            ClientsClientMock.Verify(x => x.NotifyAboutSomethingElse(), Times.Once);
        }

        [TestMethod]
        public void NotifyClientsAboutSomethingElse_ClientsNotified()
        {
            _exampleHub = new ExampleHub(DbContextMock.Object);
            AssignToHubRequiredProperties(_exampleHub);

            _exampleHub.NotifyClientsAboutSomethingElse();

            ClientsClientsMock.Verify(x => x.NotifyAboutSomethingElse(), Times.Once);
        }

        [TestMethod]
        public void NotifyGroupAboutSomethingElse_GroupNotified()
        {
            _exampleHub = new ExampleHub(DbContextMock.Object);
            AssignToHubRequiredProperties(_exampleHub);

            _exampleHub.NotifyGroupAboutSomethingElse();

            ClientsGroupMock.Verify(x => x.NotifyAboutSomethingElse(), Times.Once);
        }

        [TestMethod]
        public void NotifyGroupExceptAboutSomethingElse_GropuExceptNotified()
        {
            _exampleHub = new ExampleHub(DbContextMock.Object);
            AssignToHubRequiredProperties(_exampleHub);

            _exampleHub.NotifyGroupExceptAboutSomethingElse();

            ClientsGroupExceptMock.Verify(x => x.NotifyAboutSomethingElse(), Times.Once);
        }

        [TestMethod]
        public void NotifyGroupsAboutSomethingElse_GropusNotified()
        {
            _exampleHub = new ExampleHub(DbContextMock.Object);
            AssignToHubRequiredProperties(_exampleHub);

            _exampleHub.NotifyGroupsAboutSomethingElse();

            ClientsGroupsMock.Verify(x => x.NotifyAboutSomethingElse(), Times.Once);
        }

        [TestMethod]
        public void NotifyOthersAboutSomethingElse_OthersNotified()
        {
            _exampleHub = new ExampleHub(DbContextMock.Object);
            AssignToHubRequiredProperties(_exampleHub);

            _exampleHub.NotifyOthersAboutSomethingElse();

            ClientsOthersMock.Verify(x => x.NotifyAboutSomethingElse(), Times.Once);
        }

        [TestMethod]
        public void NotifyOthersInGroupAboutSomethingElse_OthersInGroupNotified()
        {
            _exampleHub = new ExampleHub(DbContextMock.Object);
            AssignToHubRequiredProperties(_exampleHub);

            _exampleHub.NotifyOthersInGroupAboutSomethingElse();

            ClientsOthersInGroupMock.Verify(x => x.NotifyAboutSomethingElse(), Times.Once);
        }

        [TestMethod]
        public void NotifyUserAboutSomethingElse_UserNotified()
        {
            _exampleHub = new ExampleHub(DbContextMock.Object);
            AssignToHubRequiredProperties(_exampleHub);

            _exampleHub.NotifyUserAboutSomethingElse();

            ClientsUserMock.Verify(x => x.NotifyAboutSomethingElse(), Times.Once);
        }

        [TestMethod]
        public void NotifyUsersAboutSomethingElse_UsersNotified()
        {
            _exampleHub = new ExampleHub(DbContextMock.Object);
            AssignToHubRequiredProperties(_exampleHub);

            _exampleHub.NotifyUsersAboutSomethingElse();

            ClientsUsersMock.Verify(x => x.NotifyAboutSomethingElse(), Times.Once);
        }

        [TestMethod]
        public void AddLoremAsKeyAndIpsumAsValueToContextItems_ContextContainThatKeyValuPair()
        {
            _exampleHub = new ExampleHub(DbContextMock.Object);
            AssignToHubRequiredProperties(_exampleHub);

            _exampleHub.AddLoremAsKeyAndIpsumAsValueToContextItems();

            VerifyContextItemsContainKeyValuePair("Lorem", "Ipsum");
        }

        [TestMethod]
        public void AddSomebodyToGroup_SomebodyAdded()
        {
            _exampleHub = new ExampleHub(DbContextMock.Object);
            AssignToHubRequiredProperties(_exampleHub);

            _exampleHub.AddSomebodyToGroup();

            VerifySomebodyAddedToGroup(Times.Once());
        }

        [TestMethod]
        public void RemoveSomebodyFromGroup_SomebodyRemoved()
        {
            _exampleHub = new ExampleHub(DbContextMock.Object);
            AssignToHubRequiredProperties(_exampleHub);

            _exampleHub.RemoveSomebodyFromGroup();

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
    }
}
