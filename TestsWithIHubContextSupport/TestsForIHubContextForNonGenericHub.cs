#pragma warning disable SA1009 // Closing parenthesis should be spaced correctly
#pragma warning disable SA1111 // Closing parenthesis should be on line of last parameter
using System;
using System.Threading;
using System.Threading.Tasks;
using ExampleSignalRCoreProject.Hubs;
using ExampleSignalRCoreProject.Services;
using Moq;
using NUnit.Framework;
using SignalR_UnitTestingSupportCommon.IHubContextSupport;

namespace TestsWithIHubContextSupport
{
    [TestFixture]
    public class TestsForIHubContextForNonGenericHub
    {
        private ServiceWhichUseIHubContext _service;
        private UnitTestingSupportForIHubContext<ExampleNonGenericHub> _unitTestingSupport;

        [SetUp]
        public void SetUp()
        {
            _unitTestingSupport = new UnitTestingSupportForIHubContext<ExampleNonGenericHub>();
            _service = new ServiceWhichUseIHubContext(_unitTestingSupport.IHubContextMock.Object);
        }

        [Test]
        public async Task NotifyAllAboutSomething_AllNotifiedAboutSomething()
        {
            await _service.NotifyAllAboutSomething();
            _unitTestingSupport
                .ClientsAllMock
                .Verify(x => x.SendCoreAsync(
                    ExampleNonGenericHub.NotifyUserAboutSomethingResponse,
                    Array.Empty<object>(),
                    It.IsAny<CancellationToken>()

                ), Times.Once());
        }

        [Test]
        public async Task NotifyAllExceptAboutSomething_AllExceptNotifiedAboutSomething()
        {
            await _service.NotifyAllExceptAboutSomething();
            _unitTestingSupport
                .ClientsAllExceptMock
                .Verify(x => x.SendCoreAsync(
                    ExampleNonGenericHub.NotifyUserAboutSomethingResponse,
                    Array.Empty<object>(),
                    It.IsAny<CancellationToken>()
                ), Times.Once());
        }

        [Test]
        public async Task NotifyClientsAboutSomething_ClientsNotifiedAboutSomething()
        {
            await _service.NotifyClientsAboutSomething();
            _unitTestingSupport
                .ClientsClientsMock
                .Verify(x => x.SendCoreAsync(
                    ExampleNonGenericHub.NotifyUserAboutSomethingResponse,
                    Array.Empty<object>(),
                    It.IsAny<CancellationToken>()
                ), Times.Once());
        }

        [Test]
        public async Task NotifyClientAboutSomething_ClientNotifiedAboutSomething()
        {
            await _service.NotifyClientAboutSomething();
            _unitTestingSupport
                .ClientsClientMock
                .Verify(x => x.SendCoreAsync(
                    ExampleNonGenericHub.NotifyUserAboutSomethingResponse,
                    Array.Empty<object>(),
                    It.IsAny<CancellationToken>()
                ), Times.Once());
        }

        [Test]
        public async Task NotifyGroupAboutSomething_GroupNotifiedAboutSomething()
        {
            await _service.NotifyGrgoupAboutSomething();
            _unitTestingSupport
                .ClientsGroupMock
                .Verify(x => x.SendCoreAsync(
                    ExampleNonGenericHub.NotifyUserAboutSomethingResponse,
                    Array.Empty<object>(),
                    It.IsAny<CancellationToken>()
                ), Times.Once());
        }

        [Test]
        public async Task NotifyGroupsAboutSomething_GroupsNotifiedAboutSomething()
        {
            await _service.NotifyGroupsAboutSomething();
            _unitTestingSupport
                .ClientsGroupsMock
                .Verify(x => x.SendCoreAsync(
                    ExampleNonGenericHub.NotifyUserAboutSomethingResponse,
                    Array.Empty<object>(),
                    It.IsAny<CancellationToken>()
                ), Times.Once());
        }

        [Test]
        public async Task NotifyGroupExceptAboutSomething_GroupExceptNotifiedAboutSomething()
        {
            await _service.NotifyGrgoupExceptAboutSomething();
            _unitTestingSupport
                .ClientsGroupExceptMock
                .Verify(x => x.SendCoreAsync(
                    ExampleNonGenericHub.NotifyUserAboutSomethingResponse,
                    Array.Empty<object>(),
                    It.IsAny<CancellationToken>()
                ), Times.Once());
        }

        [Test]
        public async Task NotifyUserAboutSomething_UserNotifiedAboutSomething()
        {
            await _service.NotifyUserAboutSomething();
            _unitTestingSupport
                .ClientsUserMock
                .Verify(x => x.SendCoreAsync(
                    ExampleNonGenericHub.NotifyUserAboutSomethingResponse,
                    Array.Empty<object>(),
                    It.IsAny<CancellationToken>()
                ), Times.Once());
        }

        [Test]
        public async Task NotifyUsersAboutSomething_UsersNotifiedAboutSomething()
        {
            await _service.NotifyUsersAboutSomething();
            _unitTestingSupport
                .ClientsUsersMock
                .Verify(x => x.SendCoreAsync(
                    ExampleNonGenericHub.NotifyUserAboutSomethingResponse,
                    Array.Empty<object>(),
                    It.IsAny<CancellationToken>()
                ), Times.Once());
        }
    }
}
#pragma warning restore SA1111 // Closing parenthesis should be on line of last parameter
#pragma warning restore SA1009 // Closing parenthesis should be spaced correctly
