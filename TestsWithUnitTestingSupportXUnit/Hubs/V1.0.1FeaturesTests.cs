using ExampleSignalRCoreProject.Hubs;
using Moq;
using Xunit;
using SignalR_UnitTestingSupportXUnit.Hubs;
using System;
using System.Collections.Generic;
using System.Text;

namespace TestsWithUnitTestingSupport.Hubs
{
    public class V101FeaturesTests : HubUnitTestsBase
    {
        [Fact]
        public void HubUnitTestsBaseAlwaysSameInScopeOfTest()
        {
            var hub = new V101FeaturesHub();
            AssignToHubRequiredProperties(hub);
            string connId1 = ContextMock.Object.ConnectionId;
            string connId2 = ContextMock.Object.ConnectionId;

            Assert.Equal(connId1, connId2);
        }

        [Fact]
        public void UseContextConnIdTwice_connectionIdCalledTwice()
        {
            var hub = new V101FeaturesHub();
            AssignToHubRequiredProperties(hub);

            hub.UseContextConnIdTwice();

            ContextMock.Verify(x => x.ConnectionId, Times.Exactly(2));
        }

        [Fact]
        public void VerifyUserAddedToGroupByConnId_UserAdded()
        {
            var hub = new V101FeaturesHub();
            AssignToHubRequiredProperties(hub);

            hub.AddUserToGroup();

            VerifyUserAddedToGroupByConnId(Times.Once(), ContextMock.Object.ConnectionId);
        }

        [Fact]
        public void VerifyUserRemovedFromGroupByConnId_UserAdded()
        {
            var hub = new V101FeaturesHub();
            AssignToHubRequiredProperties(hub);

            hub.RemoveUserFromGroupByConnIdGroup();

            VerifyUserRemovedFromGroupByConnId(Times.Once(), ContextMock.Object.ConnectionId);
        }
    }
}
