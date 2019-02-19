using Microsoft.AspNetCore.SignalR;
using Moq;

namespace SignalR_UnitTestingSupportCommon.Interfaces
{
    /// <summary>
    /// To be sure we implement all features for testing pure Hub&lt;T&gt;
    /// </summary>
    public interface IHubUnitTestsBase<TIHubResponses> where TIHubResponses : class
    {
        /// <summary>
        /// Mock for Hub.Clients
        /// </summary>
        Mock<IHubCallerClients<TIHubResponses>> ClientsMock { get; }

        /// <summary>
        /// Mock which is returned when Hub.Clients.AllExcept() is called
        /// </summary>
        Mock<TIHubResponses> ClientsAllExceptMock { get; }

        /// <summary>
        /// Mock for Hub.Clients.All
        /// </summary>
        Mock<TIHubResponses> ClientsAllMock { get; }

        /// <summary>
        /// Mock for Hub.Clients.Caller
        /// </summary>
        Mock<TIHubResponses> ClientsCallerMock { get; }

        /// <summary>
        /// Mock which is returned when Hub.Clients.Client() is called
        /// </summary>
        Mock<TIHubResponses> ClientsClientMock { get; }

        /// <summary>
        /// Mock which is returned when Hub.Clients.Clients() is called
        /// </summary>
        Mock<TIHubResponses> ClientsClientsMock { get; }

        /// <summary>
        /// Mock which is returned when Hub.Clients.GroupExcept() is called
        /// </summary>
        Mock<TIHubResponses> ClientsGroupExceptMock { get; }

        /// <summary>
        /// Mock which is returned when Hub.Clients.Group() is called
        /// </summary>
        Mock<TIHubResponses> ClientsGroupMock { get; }

        /// <summary>
        /// Mock which is returned when Hub.Clients.Groups() is called
        /// </summary>
        Mock<TIHubResponses> ClientsGroupsMock { get; }

        /// <summary>
        /// Mock which is returned when Hub.Clients.OthersInGroup() is called
        /// </summary>
        Mock<TIHubResponses> ClientsOthersInGroupMock { get; }

        /// <summary>
        /// Mock for Hub.Clients.Others
        /// </summary>
        Mock<TIHubResponses> ClientsOthersMock { get; }

        /// <summary>
        /// Mock which is returned when Hub.Clients.User() is called
        /// </summary>
        Mock<TIHubResponses> ClientsUserMock { get; }

        /// <summary>
        /// Mock which is returned when Hub.Clients.Users() is called
        /// </summary>
        Mock<TIHubResponses> ClientsUsersMock { get; }

        /// <summary>
        /// Assign to hub Clients, Context and Groups mocks objects.
        /// </summary>
        void AssignToHubRequiredProperties(Hub<TIHubResponses> hub);

        /// <summary>
        /// Set Up object. Prepared for testing engine 
        /// or user which decided use class which implement that interfeca as object.
        /// (instead use one of provided base classes [NUnit, xUnit, MsTest])
        /// </summary>
        void SetUp();
    }
}