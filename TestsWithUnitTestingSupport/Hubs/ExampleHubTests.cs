using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ExampleSignalRCoreProject.Databases;
using ExampleSignalRCoreProject.Hubs;
using ExampleSignalRCoreProject.Hubs.Interfaces;
using ExampleSignalRCoreProject.Models;
using Moq;
using NUnit.Framework;
using Microsoft.EntityFrameworkCore;
using SignalR_UnitTestingSupport.Hubs;
using System.Linq;

namespace TestsWithUnitTestingSupport.Hubs
{
    [TestFixture]
    class ExampleHubTests : HubUnitTestsWithEF<ExampleHubResponses, Db>
    {
        ExampleHub _exampleHub;

        [Test]
        public async Task OnConnectedAsync_AllClientsNotifiedAboutSomethingElse()
        {
            //Arrange
            _exampleHub = new ExampleHub(DbContextMock.Object);
            AssignToHubRequiredProperties(_exampleHub);

            //Action
            await  _exampleHub.OnConnectedAsync();

            //Assert
            ClientsAllMock.Verify(x => x.NotifyAboutSomethingElse(), Times.Once);
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
