using Microsoft.AspNetCore.SignalR;
using Moq;
using SignalR_UnitTestingSupportCommon.Hubs.Internal;
using System;
using System.Collections.Generic;
using System.Text;

namespace SignalR_UnitTestingSupportCommon.Hubs
{
    public class HubUnitTestsSupport<TIHubResponses> : HubUnitTestsBaseCommon
        where TIHubResponses : class
    {
        public Mock<IHubCallerClients<TIHubResponses>> ClientsMock { get; private set; }

        public Mock<TIHubResponses> ClientsAllMock { get; private set; }
        public Mock<TIHubResponses> ClientsAllExceptMock { get; private set; }
        public Mock<TIHubResponses> ClientsCallerMock { get; private set; }
        public Mock<TIHubResponses> ClientsClientMock { get; private set; }
        public Mock<TIHubResponses> ClientsClientsMock { get; private set; }
        public Mock<TIHubResponses> ClientsGroupMock { get; private set; }
        public Mock<TIHubResponses> ClientsGroupExceptMock { get; private set; }
        public Mock<TIHubResponses> ClientsGroupsMock { get; private set; }
        public Mock<TIHubResponses> ClientsOthersMock { get; private set; }
        public Mock<TIHubResponses> ClientsOthersInGroupMock { get; private set; }
        public Mock<TIHubResponses> ClientsUserMock { get; private set; }
        public Mock<TIHubResponses> ClientsUsersMock { get; private set; }

        internal override void _setUpClients()
        {
            SetUpClients();
            SetUpClientsAll();
            SetUpClientsAllExcept();
            SetUpClientsCaller();
            SetUpClientsClient();
            SetUpClientsClients();
            SetUpClientsGroup();
            SetUpClientsGroupExcept();
            SetUpClientsGroups();
            SetUpClientsOthersMock();
            SetUpClientsOthersInGroup();
            SetUpClientsUser();
            SetUpClientsUsers();
        }

        internal void SetUpClients()
        {
            ClientsMock = new Mock<IHubCallerClients<TIHubResponses>>();
        }

        internal  void SetUpClientsUsers()
        {
            ClientsUsersMock = new Mock<TIHubResponses>();
            ClientsMock
                .Setup(x => x.Users(It.IsAny<IReadOnlyList<string>>()))
                .Returns(ClientsUsersMock.Object);
        }

        internal  void SetUpClientsUser()
        {
            ClientsUserMock = new Mock<TIHubResponses>();
            ClientsMock
                .Setup(x => x.User(It.IsAny<string>()))
                .Returns(ClientsUserMock.Object);
        }

        internal  void SetUpClientsOthersInGroup()
        {
            ClientsOthersInGroupMock = new Mock<TIHubResponses>();
            ClientsMock
                .Setup(x => x.OthersInGroup(It.IsAny<string>()))
                .Returns(ClientsOthersInGroupMock.Object);
        }

        internal  void SetUpClientsOthersMock()
        {
            ClientsOthersMock = new Mock<TIHubResponses>();
            ClientsMock
                .Setup(x => x.Others)
                .Returns(ClientsOthersMock.Object);
        }

        internal  void SetUpClientsGroups()
        {
            ClientsGroupsMock = new Mock<TIHubResponses>();
            ClientsMock
                .Setup(x => x.Groups(It.IsAny<IReadOnlyList<string>>()))
                .Returns(ClientsGroupsMock.Object);
        }

        internal  void SetUpClientsGroupExcept()
        {
            ClientsGroupExceptMock = new Mock<TIHubResponses>();
            ClientsMock
                .Setup(x => x.GroupExcept(It.IsAny<string>(), It.IsAny<IReadOnlyList<string>>()))
                .Returns(ClientsGroupExceptMock.Object);
        }

        internal  void SetUpClientsGroup()
        {
            ClientsGroupMock = new Mock<TIHubResponses>();
            ClientsMock
                .Setup(x => x.Group(It.IsAny<string>()))
                .Returns(ClientsGroupMock.Object);
        }

        internal  void SetUpClientsClients()
        {
            ClientsClientsMock = new Mock<TIHubResponses>();
            ClientsMock
                .Setup(x => x.Clients(It.IsAny<IReadOnlyList<string>>()))
                .Returns(ClientsClientsMock.Object);
        }

        internal  void SetUpClientsClient()
        {
            ClientsClientMock = new Mock<TIHubResponses>();
            ClientsMock
                .Setup(x => x.Client(It.IsAny<string>()))
                .Returns(ClientsClientMock.Object);
        }

        internal  void SetUpClientsCaller()
        {
            ClientsCallerMock = new Mock<TIHubResponses>();
            ClientsMock
                .Setup(x => x.Caller)
                .Returns(ClientsCallerMock.Object);
        }

        internal  void SetUpClientsAllExcept()
        {
            ClientsAllExceptMock = new Mock<TIHubResponses>();
            ClientsMock
                .Setup(x => x.AllExcept(It.IsAny<IReadOnlyList<string>>()))
                .Returns(ClientsAllExceptMock.Object);
        }

        internal  void SetUpClientsAll()
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
