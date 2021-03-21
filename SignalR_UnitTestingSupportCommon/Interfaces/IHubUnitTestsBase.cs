using Microsoft.AspNetCore.SignalR;
using Moq;

namespace SignalR_UnitTestingSupportCommon.Interfaces
{
    /// <summary>
    /// To be sure we implement all features for testing pure Hub
    /// </summary>
    public interface IHubUnitTestsBase : ISetUpForUserAndEngine
    {
        /// <summary>
        /// Gets mock for Hub.Clients
        /// </summary>
        Mock<IHubCallerClients> ClientsMock { get; }

        /// <summary>
        /// Gets mock which is returned when Hub.Clients.AllExcept() is called
        /// </summary>
        Mock<IClientProxy> ClientsAllExceptMock { get; }

        /// <summary>
        /// Gets mock for Hub.Clients.All
        /// </summary>
        Mock<IClientProxy> ClientsAllMock { get; }

        /// <summary>
        /// Gets mock for Hub.Clients.Caller
        /// </summary>
        Mock<IClientProxy> ClientsCallerMock { get; }

        /// <summary>
        /// Gets mock which is returned when Hub.Clients.Client() is called
        /// </summary>
        Mock<IClientProxy> ClientsClientMock { get; }

        /// <summary>
        /// Gets mock which is returned when Hub.Clients.Clients() is called
        /// </summary>
        Mock<IClientProxy> ClientsClientsMock { get; }

        /// <summary>
        /// Gets mock which is returned when Hub.Clients.GroupExcept() is called
        /// </summary>
        Mock<IClientProxy> ClientsGroupExceptMock { get; }

        /// <summary>
        /// Gets mock which is returned when Hub.Clients.Group() is called
        /// </summary>
        Mock<IClientProxy> ClientsGroupMock { get; }

        /// <summary>
        /// Gets mock which is returned when Hub.Clients.Groups() is called
        /// </summary>
        Mock<IClientProxy> ClientsGroupsMock { get; }

        /// <summary>
        /// Gets mock which is returned when Hub.Clients.OthersInGroup() is called
        /// </summary>
        Mock<IClientProxy> ClientsOthersInGroupMock { get; }

        /// <summary>
        /// Gets mock for Hub.Clients.Others
        /// </summary>
        Mock<IClientProxy> ClientsOthersMock { get; }

        /// <summary>
        /// Gets mock which is returned when Hub.Clients.User() is called
        /// </summary>
        Mock<IClientProxy> ClientsUserMock { get; }

        /// <summary>
        /// Gets mock which is returned when Hub.Clients.Users() is called
        /// </summary>
        Mock<IClientProxy> ClientsUsersMock { get; }

        /// <summary>
        /// Assign to hub Clients, Context and Groups mocks objects.
        /// </summary>
        void AssignToHubRequiredProperties(Hub hub);
    }
}