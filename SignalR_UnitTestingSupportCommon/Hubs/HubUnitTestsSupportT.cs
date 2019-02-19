using Microsoft.AspNetCore.SignalR;
using Moq;
using SignalR_UnitTestingSupportCommon.Hubs.Internal;
using SignalR_UnitTestingSupportCommon.Interfaces;
using System;
using System.Collections.Generic;

namespace SignalR_UnitTestingSupportCommon.Hubs
{
    /// <summary>
    /// Base class which provide support for testing hub&lt;TIHubResponses&gt; (But without auto SetUp by any test engine)
    /// </summary>
    public abstract class HubUnitTestsSupport<TIHubResponses> : HubUnitTestsBaseCommon, IHubUnitTestsBase<TIHubResponses>
        where TIHubResponses : class
    {
        /// <summary>
        /// Mock for Hub.Clients
        /// </summary>
        public Mock<IHubCallerClients<TIHubResponses>> ClientsMock { get; private set; }

        /// <summary>
        /// Mock for Hub.Clients.All
        /// </summary>
        public Mock<TIHubResponses> ClientsAllMock { get; private set; }

        /// <summary>
        /// Mock which is returned when Hub.Clients.AllExcept() is called
        /// </summary>
        public Mock<TIHubResponses> ClientsAllExceptMock { get; private set; }

        /// <summary>
        /// Mock for Hub.Clients.Caller
        /// </summary>
        public Mock<TIHubResponses> ClientsCallerMock { get; private set; }

        /// <summary>
        /// Mock which is returned when Hub.Clients.Client() is called
        /// </summary>
        public Mock<TIHubResponses> ClientsClientMock { get; private set; }

        /// <summary>
        /// Mock which is returned when Hub.Clients.Clients() is called
        /// </summary>
        public Mock<TIHubResponses> ClientsClientsMock { get; private set; }

        /// <summary>
        /// Mock which is returned when Hub.Clients.Group() is called
        /// </summary>
        public Mock<TIHubResponses> ClientsGroupMock { get; private set; }

        /// <summary>
        /// Mock which is returned when Hub.Clients.GroupExcept() is called
        /// </summary>
        public Mock<TIHubResponses> ClientsGroupExceptMock { get; private set; }

        /// <summary>
        /// Mock which is returned when Hub.Clients.Groups() is called
        /// </summary>
        public Mock<TIHubResponses> ClientsGroupsMock { get; private set; }

        /// <summary>
        /// Mock for Hub.Clients.Others
        /// </summary>
        public Mock<TIHubResponses> ClientsOthersMock { get; private set; }

        /// <summary>
        /// Mock which is returned when Hub.Clients.OthersInGroup() is called
        /// </summary>
        public Mock<TIHubResponses> ClientsOthersInGroupMock { get; private set; }

        /// <summary>
        /// Mock which is returned when Hub.Clients.User() is called
        /// </summary>
        public Mock<TIHubResponses> ClientsUserMock { get; private set; }

        /// <summary>
        /// Mock which is returned when Hub.Clients.Users() is called
        /// </summary>
        public Mock<TIHubResponses> ClientsUsersMock { get; private set; }

        internal override void SetUpClients()
        {
            ClientsMock = new Mock<IHubCallerClients<TIHubResponses>>();
        }

        internal override void SetUpClientsUsers()
        {
            ClientsUsersMock = new Mock<TIHubResponses>();
            ClientsMock
                .Setup(x => x.Users(It.IsAny<IReadOnlyList<string>>()))
                .Returns(ClientsUsersMock.Object);
        }

        internal override void SetUpClientsUser()
        {
            ClientsUserMock = new Mock<TIHubResponses>();
            ClientsMock
                .Setup(x => x.User(It.IsAny<string>()))
                .Returns(ClientsUserMock.Object);
        }

        internal override void SetUpClientsOthersInGroup()
        {
            ClientsOthersInGroupMock = new Mock<TIHubResponses>();
            ClientsMock
                .Setup(x => x.OthersInGroup(It.IsAny<string>()))
                .Returns(ClientsOthersInGroupMock.Object);
        }

        internal override void SetUpClientsOthersMock()
        {
            ClientsOthersMock = new Mock<TIHubResponses>();
            ClientsMock
                .Setup(x => x.Others)
                .Returns(ClientsOthersMock.Object);
        }

        internal override void SetUpClientsGroups()
        {
            ClientsGroupsMock = new Mock<TIHubResponses>();
            ClientsMock
                .Setup(x => x.Groups(It.IsAny<IReadOnlyList<string>>()))
                .Returns(ClientsGroupsMock.Object);
        }

        internal override void SetUpClientsGroupExcept()
        {
            ClientsGroupExceptMock = new Mock<TIHubResponses>();
            ClientsMock
                .Setup(x => x.GroupExcept(It.IsAny<string>(), It.IsAny<IReadOnlyList<string>>()))
                .Returns(ClientsGroupExceptMock.Object);
        }

        internal override void SetUpClientsGroup()
        {
            ClientsGroupMock = new Mock<TIHubResponses>();
            ClientsMock
                .Setup(x => x.Group(It.IsAny<string>()))
                .Returns(ClientsGroupMock.Object);
        }

        internal override void SetUpClientsClients()
        {
            ClientsClientsMock = new Mock<TIHubResponses>();
            ClientsMock
                .Setup(x => x.Clients(It.IsAny<IReadOnlyList<string>>()))
                .Returns(ClientsClientsMock.Object);
        }

        internal override void SetUpClientsClient()
        {
            ClientsClientMock = new Mock<TIHubResponses>();
            ClientsMock
                .Setup(x => x.Client(It.IsAny<string>()))
                .Returns(ClientsClientMock.Object);
        }

        internal override void SetUpClientsCaller()
        {
            ClientsCallerMock = new Mock<TIHubResponses>();
            ClientsMock
                .Setup(x => x.Caller)
                .Returns(ClientsCallerMock.Object);
        }

        internal override void SetUpClientsAllExcept()
        {
            ClientsAllExceptMock = new Mock<TIHubResponses>();
            ClientsMock
                .Setup(x => x.AllExcept(It.IsAny<IReadOnlyList<string>>()))
                .Returns(ClientsAllExceptMock.Object);
        }

        internal override void SetUpClientsAll()
        {
            ClientsAllMock = new Mock<TIHubResponses>();
            ClientsMock
                .Setup(x => x.All)
                .Returns(ClientsAllMock.Object);
        }

        /// <summary>
        /// Assign to hub Clients, Context and Groups mocks objects.
        /// </summary>
        public void AssignToHubRequiredProperties(Hub<TIHubResponses> hub)
        {
            if (hub == null)
                throw new ArgumentNullException("Hub not initialized");

            hub.Clients = ClientsMock.Object;
            hub.Context = ContextMock.Object;
            hub.Groups = GroupsMock.Object;
        }
    }
}
