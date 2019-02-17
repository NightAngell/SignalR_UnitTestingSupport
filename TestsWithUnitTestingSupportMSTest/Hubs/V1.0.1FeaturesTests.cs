using ExampleSignalRCoreProject.Hubs;
using Moq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SignalR_UnitTestingSupportMSTest.Hubs;
using System;
using System.Collections.Generic;
using System.Text;

namespace TestsWithUnitTestingSupport.Hubs
{
    [TestClass]
    public class V101FeaturesTests : HubUnitTestsBase
    {
        [TestMethod]
        public void HubUnitTestsBaseAlwaysSameInScopeOfTest()
        {
            var hub = new V101FeaturesHub();
            AssignToHubRequiredProperties(hub);
            string connId1 = ContextMock.Object.ConnectionId;
            string connId2 = ContextMock.Object.ConnectionId;

            Assert.AreEqual(connId1, connId2);
        }

        [TestMethod]
        public void UseContextConnIdTwice_connectionIdCalledTwice()
        {
            var hub = new V101FeaturesHub();
            AssignToHubRequiredProperties(hub);

            hub.UseContextConnIdTwice();

            ContextMock.Verify(x => x.ConnectionId, Times.Exactly(2));
        }

        [TestMethod]
        public void VerifyUserAddedToGroupByConnId_UserAdded()
        {
            var hub = new V101FeaturesHub();
            AssignToHubRequiredProperties(hub);

            hub.AddUserToGroup();

            VerifyUserAddedToGroupByConnId(Times.Once(), ContextMock.Object.ConnectionId);
        }

        [TestMethod]
        public void VerifyUserRemovedFromGroupByConnId_UserAdded()
        {
            var hub = new V101FeaturesHub();
            AssignToHubRequiredProperties(hub);

            hub.RemoveUserFromGroupByConnIdGroup();

            VerifyUserRemovedFromGroupByConnId(Times.Once(), ContextMock.Object.ConnectionId);
        }
    }
}
