using Microsoft.AspNetCore.SignalR;
using Moq;

namespace SignalR_UnitTestingSupportCommon.Interfaces
{
    /// <summary>
    /// To be sure we implement all features for testing pure Hub
    /// </summary>
    public interface IHubUnitTestsBase
    {
        Mock<IHubCallerClients> ClientsMock { get; }
        Mock<IClientProxy> ClientsAllExceptMock { get; }
        Mock<IClientProxy> ClientsAllMock { get; }
        Mock<IClientProxy> ClientsCallerMock { get; }
        Mock<IClientProxy> ClientsClientMock { get; }
        Mock<IClientProxy> ClientsClientsMock { get; }
        Mock<IClientProxy> ClientsGroupExceptMock { get; }
        Mock<IClientProxy> ClientsGroupMock { get; }
        Mock<IClientProxy> ClientsGroupsMock { get; }
        Mock<IClientProxy> ClientsOthersInGroupMock { get; }
        Mock<IClientProxy> ClientsOthersMock { get; }
        Mock<IClientProxy> ClientsUserMock { get; }
        Mock<IClientProxy> ClientsUsersMock { get; }

        void AssignToHubRequiredProperties(Hub hub);
    }
}