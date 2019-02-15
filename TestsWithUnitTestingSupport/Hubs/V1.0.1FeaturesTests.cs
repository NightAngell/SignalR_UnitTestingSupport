using ExampleSignalRCoreProject.Hubs;
using Moq;
using NUnit.Framework;
using SignalR_UnitTestingSupport.Hubs;
using System;
using System.Collections.Generic;
using System.Text;

namespace TestsWithUnitTestingSupport.Hubs
{
    [TestFixture]
    class V101FeaturesTests : HubUnitTestsBase
    {
        [Test]
        public void HubUnitTestsBaseAlwaysSameInScopeOfTest()
        {
            var hub = new V101FeaturesHub();
            AssignToHubRequiredProperties(hub);
            string connId1 = ContextMock.Object.ConnectionId;
            string connId2 = ContextMock.Object.ConnectionId;

            Assert.AreEqual(connId1, connId2);
        }

        [Test]
        public void UseContextConnIdTwice_connectionIdCalledTwice()
        {
            var hub = new V101FeaturesHub();
            AssignToHubRequiredProperties(hub);

            hub.UseContextConnIdTwice();

            ContextMock.Verify(x => x.ConnectionId, Times.Exactly(2));
        }

        [Test]
        public void VerifyUserAddedToGroupByConnId_UserAdded()
        {
            var hub = new V101FeaturesHub();
            AssignToHubRequiredProperties(hub);

            hub.AddUserToGroup();

            VerifyUserAddedToGroupByConnId(Times.Once(), ContextMock.Object.ConnectionId);
        }

        [Test]
        public void VerifyUserRemovedFromGroupByConnId_UserAdded()
        {
            var hub = new V101FeaturesHub();
            AssignToHubRequiredProperties(hub);

            hub.RemoveUserFromGroupByConnIdGroup();

            VerifyUserRemovedFromGroupByConnId(Times.Once(), ContextMock.Object.ConnectionId);
        }
    }
}
