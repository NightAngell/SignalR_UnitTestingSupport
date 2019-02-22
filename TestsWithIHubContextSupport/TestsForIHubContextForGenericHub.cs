using ExampleSignalRCoreProject.Hubs;
using ExampleSignalRCoreProject.Hubs.Interfaces;
using ExampleSignalRCoreProject.Services;
using Moq;
using NUnit.Framework;
using SignalR_UnitTestingSupportCommon.IHubContextSupport;
using System.Threading;
using System.Threading.Tasks;

namespace TestsWithIHubContextSupport
{
    [TestFixture]
    public class TestsForIHubContextForGenericHub
    {
        ServiceWhichUserGenericIHubContext service;
        UnitTestingSupportForIHubContext<ExampleHub, ExampleHubResponses> unitTestingSupport;

        [SetUp]
        public void SetUp()
        {
            unitTestingSupport = new UnitTestingSupportForIHubContext<ExampleHub, ExampleHubResponses>();
            service = new ServiceWhichUserGenericIHubContext(unitTestingSupport.IHubContextMock.Object);
        }

        [Test]
        public void NotifyAllAboutSomethingElse_AllNotifiedAboutSomethingElse()
        {
            service.NotifyAllAboutSomethingElse();
            unitTestingSupport
                .ClientsAllMock
                .Verify(x => x.NotifyAboutSomethingElse(), 
                    Times.Once());
        }

        [Test]
        public void NotifyAllExceptAboutSomethingElse_AllExceptNotifiedAboutSomethingElse()
        {
            service.NotifyAboutSomethingElseAllExcept();
            unitTestingSupport
                .ClientsAllExceptMock
                .Verify(x => x.NotifyAboutSomethingElse(), 
                Times.Once());
        }

        [Test]
        public void NotifyClientsAboutSomethingElse_ClientsNotifiedAboutSomethingElse()
        {
            service.NotifyClientsAboutSomethingElse();
            unitTestingSupport
                .ClientsClientsMock
                .Verify(x => x.NotifyAboutSomethingElse(), Times.Once());
        }

        [Test]
        public void NotifyClientAboutSomethingElse_ClientNotifiedAboutSomethingElse()
        {
            service.NotifyClientAboutSomethingElse();
            unitTestingSupport
                .ClientsClientMock
                .Verify(x => x.NotifyAboutSomethingElse(), Times.Once());
        }

        [Test]
        public void NotifyGroupAboutSomethingElse_GroupNotifiedAboutSomethingElse()
        {
            service.NotifyGroupAboutSomethingElse();
            unitTestingSupport
                .ClientsGroupMock
                .Verify(x => x.NotifyAboutSomethingElse(), Times.Once());
        }

        [Test]
        public void NotifyGroupsAboutSomethingElse_GroupsNotifiedAboutSomethingElse()
        {
            service.NotifyGroupsAboutSomethingElse();
            unitTestingSupport
                .ClientsGroupsMock
                .Verify(x => x.NotifyAboutSomethingElse(), Times.Once());
        }

        [Test]
        public void NotifyGroupExceptAboutSomethingElse_GroupExceptNotifiedAboutSomethingElse()
        {
            service.NotifyGroupExceptAboutSomethingElse();
            unitTestingSupport
                .ClientsGroupExceptMock
                .Verify(x => x.NotifyAboutSomethingElse(), Times.Once());
        }

        [Test]
        public void NotifyUserAboutSomethingElse_UserNotifiedAboutSomethingElse()
        {
            service.NotifyUserAboutSomethingElse();
            unitTestingSupport
                .ClientsUserMock
                .Verify(x => x.NotifyAboutSomethingElse(), Times.Once());
        }

        [Test]
        public void NotifyUsersAboutSomething_UsersNotifiedAboutSomething()
        {
            service.NotifyUsersAboutSomethingElse();
            unitTestingSupport
                .ClientsUsersMock
                .Verify(x => x.NotifyAboutSomethingElse(), Times.Once());
        }
    }
}
