using Microsoft.AspNetCore.SignalR;
using Moq;

namespace SignalR_UnitTestingSupportCommon.Interfaces
{
    /// <summary>
    /// To be sure we implement all features for testing pure Hub<T>
    /// </summary>
    public interface IHubUnitTestsBase<TIHubResponses> where TIHubResponses : class
    {
        Mock<IHubCallerClients<TIHubResponses>> ClientsMock { get; }

        Mock<TIHubResponses> ClientsAllExceptMock { get; }
        Mock<TIHubResponses> ClientsAllMock { get; }
        Mock<TIHubResponses> ClientsCallerMock { get; }
        Mock<TIHubResponses> ClientsClientMock { get; }
        Mock<TIHubResponses> ClientsClientsMock { get; }
        Mock<TIHubResponses> ClientsGroupExceptMock { get; }
        Mock<TIHubResponses> ClientsGroupMock { get; }
        Mock<TIHubResponses> ClientsGroupsMock { get; }
        Mock<TIHubResponses> ClientsOthersInGroupMock { get; }
        Mock<TIHubResponses> ClientsOthersMock { get; }
        Mock<TIHubResponses> ClientsUserMock { get; }
        Mock<TIHubResponses> ClientsUsersMock { get; }

        void AssignToHubRequiredProperties(Hub<TIHubResponses> hub);
    }
}