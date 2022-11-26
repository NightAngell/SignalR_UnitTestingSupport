using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ExampleSignalRCoreProject.Databases;
using ExampleSignalRCoreProject.Hubs;
using ExampleSignalRCoreProject.Models;
using Moq;
using SignalR_UnitTestingSupportXUnit.Hubs;
using Xunit;

namespace TestsWithUnitTestingSupport.Hubs
{
    public class ExampleNonGenericHubTests : HubUnitTestsWithEF<Db>
    {
        private ExampleNonGenericHub _exampleHub;

        public ExampleNonGenericHubTests() : base()
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
            Assert.True(DbInMemorySqlite.Note.Count() == 0);
        }

        [Fact]
        public void TryGetDbInMemory_ClearDbInMemoryMockSuccesfullyTaken()
        {
            Assert.True(DbInMemory.Note.Count() == 0);
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Usage", "xUnit1026:Theory methods should use all of their parameters", Justification = "This param is required here")]
#pragma warning disable IDE0060 // Remove unused parameter
        public async Task TryGetDbInMemorySqlite_WeGetClearInstanceOfDbInEveryTest(bool twiceCalledTest)
#pragma warning restore IDE0060 // Remove unused parameter
        {
            Assert.True(DbInMemorySqlite.Note.Count() == 0);

            DbInMemorySqlite.Note.Add(new Note { Content = "test content" });
            await DbInMemorySqlite.SaveChangesAsync();
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Usage", "xUnit1026:Theory methods should use all of their parameters", Justification = "This param is required here")]
#pragma warning disable IDE0060 // Remove unused parameter
        public async Task TryGetDbInMemory_WeGetClearInstanceOfDbInEveryTest(bool twiceCalledTest)
#pragma warning restore IDE0060 // Remove unused parameter
        {
            Assert.True(DbInMemory.Note.Count() == 0);

            DbInMemory.Note.Add(new Note { Content = "test content" });
            await DbInMemory.SaveChangesAsync();
        }

        [Fact]
        public async Task NotifyAllAboutSomething_AllNotifiedAboutSomething()
        {
            _exampleHub = new ExampleNonGenericHub();
            AssignToHubRequiredProperties(_exampleHub);

            await _exampleHub.NotifyAllAboutSomething();

            ClientsAllMock
                .Verify(x => x.SendCoreAsync("NotifyUserAboutSomething", System.Array.Empty<object>(), It.IsAny<CancellationToken>()));
        }

        [Fact]
        public async Task NotifyAllExceptAboutSomething_AllExceptNotifiedAboutSomething()
        {
            _exampleHub = new ExampleNonGenericHub();
            AssignToHubRequiredProperties(_exampleHub);

            await _exampleHub.NotifyAllExceptAboutSomething();

            ClientsAllExceptMock
                .Verify(x => x.SendCoreAsync("NotifyUserAboutSomething", System.Array.Empty<object>(), It.IsAny<CancellationToken>()));
        }

        [Fact]
        public async Task NotifyCallerAboutSomething_CallerNotifiedAboutSomething()
        {
            _exampleHub = new ExampleNonGenericHub();
            AssignToHubRequiredProperties(_exampleHub);

            await _exampleHub.NotifyCallerAboutSomething();

            ClientsCallerMock
                .Verify(x => x.SendCoreAsync("NotifyUserAboutSomething", System.Array.Empty<object>(), It.IsAny<CancellationToken>()));
        }

        [Fact]
        public async Task NotifyClientAboutSomething_ClientNotifiedAboutSomething()
        {
            _exampleHub = new ExampleNonGenericHub();
            AssignToHubRequiredProperties(_exampleHub);

            await _exampleHub.NotifyClientAboutSomething();

            ClientsClientMock
                .Verify(x => x.SendCoreAsync("NotifyUserAboutSomething", System.Array.Empty<object>(), It.IsAny<CancellationToken>()));
        }

        [Fact]
        public async Task NotifyClientsAboutSomething_ClientsNotifiedAboutSomething()
        {
            _exampleHub = new ExampleNonGenericHub();
            AssignToHubRequiredProperties(_exampleHub);

            await _exampleHub.NotifyClientsAboutSomething();

            ClientsClientsMock
                .Verify(x => x.SendCoreAsync("NotifyUserAboutSomething", System.Array.Empty<object>(), It.IsAny<CancellationToken>()));
        }

        [Fact]
        public async Task NotifyGroupAboutSomething_GroupNotifiedAboutSomething()
        {
            _exampleHub = new ExampleNonGenericHub();
            AssignToHubRequiredProperties(_exampleHub);

            await _exampleHub.NotifyGrgoupAboutSomething();

            ClientsGroupMock
                .Verify(x => x.SendCoreAsync("NotifyUserAboutSomething", System.Array.Empty<object>(), It.IsAny<CancellationToken>()));
        }

        [Fact]
        public async Task NotifyGroupExceptAboutSomething_GroupExceptNotifiedAboutSomething()
        {
            _exampleHub = new ExampleNonGenericHub();
            AssignToHubRequiredProperties(_exampleHub);

            await _exampleHub.NotifyGrgoupExceptAboutSomething();

            ClientsGroupExceptMock
                .Verify(x => x.SendCoreAsync("NotifyUserAboutSomething", System.Array.Empty<object>(), It.IsAny<CancellationToken>()));
        }

        [Fact]
        public async Task NotifyGroupsAboutSomething_GroupsNotifiedAboutSomething()
        {
            _exampleHub = new ExampleNonGenericHub();
            AssignToHubRequiredProperties(_exampleHub);

            await _exampleHub.NotifyGroupsAboutSomething();

            ClientsGroupsMock
                .Verify(x => x.SendCoreAsync("NotifyUserAboutSomething", System.Array.Empty<object>(), It.IsAny<CancellationToken>()));
        }

        [Fact]
        public async Task NotifyOthersAboutSomething_OthersAboutNotifiedSomething()
        {
            _exampleHub = new ExampleNonGenericHub();
            AssignToHubRequiredProperties(_exampleHub);

            await _exampleHub.NotifyOthersAboutSomething();

            ClientsOthersMock
                .Verify(x => x.SendCoreAsync("NotifyUserAboutSomething", System.Array.Empty<object>(), It.IsAny<CancellationToken>()));
        }

        [Fact]
        public async Task NotifyOthersInGroupAboutSomething_OthersInGroupNotifiedAboutSomething()
        {
            _exampleHub = new ExampleNonGenericHub();
            AssignToHubRequiredProperties(_exampleHub);

            await _exampleHub.NotifyOthersInGroupAboutSomething();

            ClientsOthersInGroupMock
                .Verify(x => x.SendCoreAsync("NotifyUserAboutSomething", System.Array.Empty<object>(), It.IsAny<CancellationToken>()));
        }

        [Fact]
        public async Task NotifyUserAboutSomething_UserNotifiedAboutSomething()
        {
            _exampleHub = new ExampleNonGenericHub();
            AssignToHubRequiredProperties(_exampleHub);

            await _exampleHub.NotifyUserAboutSomething();

            ClientsUserMock
                .Verify(x => x.SendCoreAsync("NotifyUserAboutSomething", System.Array.Empty<object>(), It.IsAny<CancellationToken>()));
        }

        [Fact]
        public async Task NotifyUsersAboutSomething_UsersNotifiedAboutSomething()
        {
            _exampleHub = new ExampleNonGenericHub();
            AssignToHubRequiredProperties(_exampleHub);

            await _exampleHub.NotifyUsersAboutSomething();

            ClientsUsersMock
                .Verify(x => x.SendCoreAsync("NotifyUserAboutSomething", System.Array.Empty<object>(), It.IsAny<CancellationToken>()));
        }

        [Fact]
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

            Assert.Equal(expectedMessage, message);
        }
    }
}
