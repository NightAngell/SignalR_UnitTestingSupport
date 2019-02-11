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
            _exampleHub = new ExampleHub(_dbContextMock.Object);
            _assignToHubRequiredProperties(_exampleHub);
            await  _exampleHub.OnConnectedAsync();

            _clientsAllMock.Verify(x => x.NotifyAboutSomethingElse(), Times.Once);
        }

        [Test]
        public async Task AddNoteWithLoremIpsumAsContentToDb_dbProviderIsSqliteInMemory_NoteAdded()
        {
            _exampleHub = new ExampleHub(_dbInMemorySqlite);
            _assignToHubRequiredProperties(_exampleHub);

            await _exampleHub.AddNoteWithLoremIpsumAsContentToDb();

            var noteFromDb = _dbInMemorySqlite.Note.FirstOrDefault();
            Assert.NotNull(noteFromDb);
        }


    }
}
