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
        public void NotifyAllAboutSomethingElse_AllNotifiedAboutSomethingElse()
        {
            _service.NotifyAllAboutSomethingElse();
            _unitTestingSupport
                .ClientsAllMock
                .Verify(x => x.NotifyAboutSomethingElse(), 
                    Times.Once());
        }

        [Test]
        public void NotifyAllExceptAboutSomethingElse_AllExceptNotifiedAboutSomethingElse()
        {
            _service.NotifyAboutSomethingElseAllExcept();
            _unitTestingSupport
                .ClientsAllExceptMock
                .Verify(x => x.NotifyAboutSomethingElse(), 
                Times.Once());
        }

        [Test]
        public void NotifyClientsAboutSomethingElse_ClientsNotifiedAboutSomethingElse()
        {
            _service.NotifyClientsAboutSomethingElse();
            _unitTestingSupport
                .ClientsClientsMock
                .Verify(x => x.NotifyAboutSomethingElse(), Times.Once());
        }

        [Test]
        public void NotifyClientAboutSomethingElse_ClientNotifiedAboutSomethingElse()
        {
            _service.NotifyClientAboutSomethingElse();
            _unitTestingSupport
                .ClientsClientMock
                .Verify(x => x.NotifyAboutSomethingElse(), Times.Once());
        }

        [Test]
        public void NotifyGroupAboutSomethingElse_GroupNotifiedAboutSomethingElse()
        {
            _service.NotifyGroupAboutSomethingElse();
            _unitTestingSupport
                .ClientsGroupMock
                .Verify(x => x.NotifyAboutSomethingElse(), Times.Once());
        }

        [Test]
        public void NotifyGroupsAboutSomethingElse_GroupsNotifiedAboutSomethingElse()
        {
            _service.NotifyGroupsAboutSomethingElse();
            _unitTestingSupport
                .ClientsGroupsMock
                .Verify(x => x.NotifyAboutSomethingElse(), Times.Once());
        }

        [Test]
        public void NotifyGroupExceptAboutSomethingElse_GroupExceptNotifiedAboutSomethingElse()
        {
            _service.NotifyGroupExceptAboutSomethingElse();
            _unitTestingSupport
                .ClientsGroupExceptMock
                .Verify(x => x.NotifyAboutSomethingElse(), Times.Once());
        }

        [Test]
        public void NotifyUserAboutSomethingElse_UserNotifiedAboutSomethingElse()
        {
            _service.NotifyUserAboutSomethingElse();
            _unitTestingSupport
                .ClientsUserMock
                .Verify(x => x.NotifyAboutSomethingElse(), Times.Once());
        }

        [Test]
        public void NotifyUsersAboutSomething_UsersNotifiedAboutSomething()
        {
            _service.NotifyUsersAboutSomethingElse();
            _unitTestingSupport
                .ClientsUsersMock
                .Verify(x => x.NotifyAboutSomethingElse(), Times.Once());
        }
    }
}
