using System.Threading.Tasks;
using ExampleSignalRCoreProject.Hubs;
using ExampleSignalRCoreProject.Hubs.Interfaces;
using ExampleSignalRCoreProject.Services;
using Moq;
using NUnit.Framework;
using SignalR_UnitTestingSupportCommon.IHubContextSupport;

namespace TestsWithIHubContextSupport
{
    [TestFixture]
    public class TestsForIHubContextForGenericHub
    {
        private ServiceWhichUserGenericIHubContext _service;
        private UnitTestingSupportForIHubContext<ExampleHub, IExampleHubResponses> _unitTestingSupport;

        [SetUp]
        public void SetUp()
        {
            _unitTestingSupport = new UnitTestingSupportForIHubContext<ExampleHub, IExampleHubResponses>();
            _service = new ServiceWhichUserGenericIHubContext(_unitTestingSupport.IHubContextMock.Object);
        }

        [Test]
        public async Task NotifyAllAboutSomethingElse_AllNotifiedAboutSomethingElseAsync()
        {
            await _service.NotifyAllAboutSomethingElse();
            _unitTestingSupport
                .ClientsAllMock
                .Verify(x => x.NotifyAboutSomethingElse(), 
                    Times.Once());
        }

        [Test]
        public async Task NotifyAllExceptAboutSomethingElse_AllExceptNotifiedAboutSomethingElseAsync()
        {
            await _service.NotifyAboutSomethingElseAllExcept();
            _unitTestingSupport
                .ClientsAllExceptMock
                .Verify(x => x.NotifyAboutSomethingElse(), 
                Times.Once());
        }

        [Test]
        public async Task NotifyClientsAboutSomethingElse_ClientsNotifiedAboutSomethingElseAsync()
        {
            await _service.NotifyClientsAboutSomethingElse();
            _unitTestingSupport
                .ClientsClientsMock
                .Verify(x => x.NotifyAboutSomethingElse(), Times.Once());
        }

        [Test]
        public async Task NotifyClientAboutSomethingElse_ClientNotifiedAboutSomethingElseAsync()
        {
            await _service.NotifyClientAboutSomethingElse();
            _unitTestingSupport
                .ClientsClientMock
                .Verify(x => x.NotifyAboutSomethingElse(), Times.Once());
        }

        [Test]
        public async Task NotifyGroupAboutSomethingElse_GroupNotifiedAboutSomethingElseAsync()
        {
            await _service.NotifyGroupAboutSomethingElse();
            _unitTestingSupport
                .ClientsGroupMock
                .Verify(x => x.NotifyAboutSomethingElse(), Times.Once());
        }

        [Test]
        public async Task NotifyGroupsAboutSomethingElse_GroupsNotifiedAboutSomethingElseAsync()
        {
            await _service.NotifyGroupsAboutSomethingElse();
            _unitTestingSupport
                .ClientsGroupsMock
                .Verify(x => x.NotifyAboutSomethingElse(), Times.Once());
        }

        [Test]
        public async Task NotifyGroupExceptAboutSomethingElse_GroupExceptNotifiedAboutSomethingElseAsync()
        {
            await _service.NotifyGroupExceptAboutSomethingElse();
            _unitTestingSupport
                .ClientsGroupExceptMock
                .Verify(x => x.NotifyAboutSomethingElse(), Times.Once());
        }

        [Test]
        public async Task NotifyUserAboutSomethingElse_UserNotifiedAboutSomethingElseAsync()
        {
            await _service.NotifyUserAboutSomethingElse();
            _unitTestingSupport
                .ClientsUserMock
                .Verify(x => x.NotifyAboutSomethingElse(), Times.Once());
        }

        [Test]
        public async Task NotifyUsersAboutSomething_UsersNotifiedAboutSomethingAsync()
        {
            await _service.NotifyUsersAboutSomethingElse();
            _unitTestingSupport
                .ClientsUsersMock
                .Verify(x => x.NotifyAboutSomethingElse(), Times.Once());
        }

        [Test]
        public async Task GetMessageFromClient_MessageReceived()
        {
            var expectedMessage = "Pizza!";
            _unitTestingSupport
                .ClientsClientMock
                .Setup(x => x.GetMessage())
                .Returns(Task.FromResult(expectedMessage));

            var message = await _service.GetMessageFromClient();

            Assert.That(message, Is.EqualTo(expectedMessage));
        }
    }
}
