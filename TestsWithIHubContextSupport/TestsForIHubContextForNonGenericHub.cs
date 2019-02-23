using ExampleSignalRCoreProject.Hubs;
using ExampleSignalRCoreProject.Services;
using Moq;
using NUnit.Framework;
using SignalR_UnitTestingSupportCommon.IHubContextSupport;
using System.Threading;
using System.Threading.Tasks;

namespace TestsWithIHubContextSupport
{
    [TestFixture]
    public class TestsForIHubContextForNonGenericHub
    {
        ServiceWhichUseIHubContext service;
        UnitTestingSupportForIHubContext<ExampleNonGenericHub> unitTestingSupport;

        [SetUp]
        public void SetUp()
        {
            unitTestingSupport = new UnitTestingSupportForIHubContext<ExampleNonGenericHub>();
            service = new ServiceWhichUseIHubContext(unitTestingSupport.IHubContextMock.Object);
        }

        [Test]
        public async Task NotifyAllAboutSomething_AllNotifiedAboutSomething()
        {
            await service.NotifyAllAboutSomething();
            unitTestingSupport
                .ClientsAllMock
                .Verify(x => x.SendCoreAsync(
                    ExampleNonGenericHub.NotifyUserAboutSomethingResponse,
                    new object [] {},
                    It.IsAny<CancellationToken>()
                ), Times.Once());
        }

        [Test]
        public async Task NotifyAllExceptAboutSomething_AllExceptNotifiedAboutSomething()
        {
            await service.NotifyAllExceptAboutSomething();
            unitTestingSupport
                .ClientsAllExceptMock
                .Verify(x => x.SendCoreAsync(
                    ExampleNonGenericHub.NotifyUserAboutSomethingResponse,
                    new object[] { },
                    It.IsAny<CancellationToken>()
                ), Times.Once());
        }

        [Test]
        public async Task NotifyClientsAboutSomething_ClientsNotifiedAboutSomething()
        {
            await service.NotifyClientsAboutSomething();
            unitTestingSupport
                .ClientsClientsMock
                .Verify(x => x.SendCoreAsync(
                    ExampleNonGenericHub.NotifyUserAboutSomethingResponse,
                    new object[] { },
                    It.IsAny<CancellationToken>()
                ), Times.Once());
        }

        [Test]
        public async Task NotifyClientAboutSomething_ClientNotifiedAboutSomething()
        {
            await service.NotifyClientAboutSomething();
            unitTestingSupport
                .ClientsClientMock
                .Verify(x => x.SendCoreAsync(
                    ExampleNonGenericHub.NotifyUserAboutSomethingResponse,
                    new object[] { },
                    It.IsAny<CancellationToken>()
                ), Times.Once());
        }

        [Test]
        public async Task NotifyGroupAboutSomething_GroupNotifiedAboutSomething()
        {
            await service.NotifyGrgoupAboutSomething();
            unitTestingSupport
                .ClientsGroupMock
                .Verify(x => x.SendCoreAsync(
                    ExampleNonGenericHub.NotifyUserAboutSomethingResponse,
                    new object[] { },
                    It.IsAny<CancellationToken>()
                ), Times.Once());
        }

        [Test]
        public async Task NotifyGroupsAboutSomething_GroupsNotifiedAboutSomething()
        {
            await service.NotifyGroupsAboutSomething();
            unitTestingSupport
                .ClientsGroupsMock
                .Verify(x => x.SendCoreAsync(
                    ExampleNonGenericHub.NotifyUserAboutSomethingResponse,
                    new object[] { },
                    It.IsAny<CancellationToken>()
                ), Times.Once());
        }

        [Test]
        public async Task NotifyGroupExceptAboutSomething_GroupExceptNotifiedAboutSomething()
        {
            await service.NotifyGrgoupExceptAboutSomething();
            unitTestingSupport
                .ClientsGroupExceptMock
                .Verify(x => x.SendCoreAsync(
                    ExampleNonGenericHub.NotifyUserAboutSomethingResponse,
                    new object[] { },
                    It.IsAny<CancellationToken>()
                ), Times.Once());
        }

        [Test]
        public async Task NotifyUserAboutSomething_UserNotifiedAboutSomething()
        {
            await service.NotifyUserAboutSomething();
            unitTestingSupport
                .ClientsUserMock
                .Verify(x => x.SendCoreAsync(
                    ExampleNonGenericHub.NotifyUserAboutSomethingResponse,
                    new object[] { },
                    It.IsAny<CancellationToken>()
                ), Times.Once());
        }

        [Test]
        public async Task NotifyUsersAboutSomething_UsersNotifiedAboutSomething()
        {
            await service.NotifyUsersAboutSomething();
            unitTestingSupport
                .ClientsUsersMock
                .Verify(x => x.SendCoreAsync(
                    ExampleNonGenericHub.NotifyUserAboutSomethingResponse,
                    new object[] { },
                    It.IsAny<CancellationToken>()
                ), Times.Once());
        }
    }
}
