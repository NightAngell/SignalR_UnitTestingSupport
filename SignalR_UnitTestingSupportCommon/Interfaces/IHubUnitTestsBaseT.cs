using Microsoft.AspNetCore.SignalR;
using Moq;

namespace SignalR_UnitTestingSupportCommon.Interfaces
{
    /// <summary>
    /// To be sure we implement all features for testing pure Hub&lt;T&gt;
    /// </summary>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1649:File name should match first type name", Justification = "I want to avoid breaking change by accident")]
    public interface IHubUnitTestsBase<TIHubResponses> : ISetUpForUserAndEngine
        where TIHubResponses : class
    {
        /// <summary>
        /// Gets mock for Hub.Clients
        /// </summary>
        Mock<IHubCallerClients<TIHubResponses>> ClientsMock { get; }

        /// <summary>
        /// Gets mock which is returned when Hub.Clients.AllExcept() is called
        /// </summary>
        Mock<TIHubResponses> ClientsAllExceptMock { get; }

        /// <summary>
        /// Gets mock for Hub.Clients.All
        /// </summary>
        Mock<TIHubResponses> ClientsAllMock { get; }

        /// <summary>
        /// Gets mock for Hub.Clients.Caller
        /// </summary>
        Mock<TIHubResponses> ClientsCallerMock { get; }

        /// <summary>
        /// Gets mock which is returned when Hub.Clients.Client() is called
        /// </summary>
        Mock<TIHubResponses> ClientsClientMock { get; }

        /// <summary>
        /// Gets mock which is returned when Hub.Clients.Clients() is called
        /// </summary>
        Mock<TIHubResponses> ClientsClientsMock { get; }

        /// <summary>
        /// Gets mock which is returned when Hub.Clients.GroupExcept() is called
        /// </summary>
        Mock<TIHubResponses> ClientsGroupExceptMock { get; }

        /// <summary>
        /// Gets mock which is returned when Hub.Clients.Group() is called
        /// </summary>
        Mock<TIHubResponses> ClientsGroupMock { get; }

        /// <summary>
        /// Gets mock which is returned when Hub.Clients.Groups() is called
        /// </summary>
        Mock<TIHubResponses> ClientsGroupsMock { get; }

        /// <summary>
        /// Gets mock which is returned when Hub.Clients.OthersInGroup() is called
        /// </summary>
        Mock<TIHubResponses> ClientsOthersInGroupMock { get; }

        /// <summary>
        /// Gets mock for Hub.Clients.Others
        /// </summary>
        Mock<TIHubResponses> ClientsOthersMock { get; }

        /// <summary>
        /// Gets mock which is returned when Hub.Clients.User() is called
        /// </summary>
        Mock<TIHubResponses> ClientsUserMock { get; }

        /// <summary>
        /// Gets mock which is returned when Hub.Clients.Users() is called
        /// </summary>
        Mock<TIHubResponses> ClientsUsersMock { get; }

        /// <summary>
        /// Assign to hub Clients, Context and Groups mocks objects.
        /// </summary>
        void AssignToHubRequiredProperties(Hub<TIHubResponses> hub);
    }
}