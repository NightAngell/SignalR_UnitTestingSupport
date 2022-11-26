using System.Threading.Tasks;
using ExampleSignalRCoreProject.Hubs;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SignalR_UnitTestingSupportMSTest.Hubs;

namespace TestsWithUnitTestingSupport.Hubs
{
    [TestClass]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1649:File name should match first type name", Justification = "Legacy name")]
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
        public async Task VerifyUserAddedToGroupByConnId_UserAddedAsync()
        {
            var hub = new V101FeaturesHub();
            AssignToHubRequiredProperties(hub);

            await hub.AddUserToGroup();

            VerifyUserAddedToGroupByConnId(Times.Once(), ContextMock.Object.ConnectionId);
        }

        [TestMethod]
        public async Task VerifyUserRemovedFromGroupByConnId_UserAddedAsync()
        {
            var hub = new V101FeaturesHub();
            AssignToHubRequiredProperties(hub);

            await hub.RemoveUserFromGroupByConnIdGroup();

            VerifyUserRemovedFromGroupByConnId(Times.Once(), ContextMock.Object.ConnectionId);
        }
    }
}
