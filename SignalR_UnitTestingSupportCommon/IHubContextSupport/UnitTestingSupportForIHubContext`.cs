using Microsoft.AspNetCore.SignalR;
using Moq;
using SignalR_UnitTestingSupportCommon.Internal;
using System.Collections.Generic;

namespace SignalR_UnitTestingSupportCommon.IHubContextSupport
{
    /// <summary>
    /// It provide preconfigured IHubContext mock and other mocks required to testing.
    /// </summary>
    public class UnitTestingSupportForIHubContext<THub, THubResponses> : SignalRUnitTestingSupportCommon
        where THubResponses : class
        where THub : Hub<THubResponses>
    {
        /// <summary>
        /// Mock for Microsoft.AspNetCore.SignalR.IHubContext&lt;THub, THubResponses&gt;
        /// </summary>
        public Mock<IHubContext<THub, THubResponses>> HubContextMock { get; protected set; }

        /// <summary>
        /// Mock for IHubContext.Clients
        /// </summary>
        public Mock<IHubClients<THubResponses>> ClientsMock { get; protected set; }

        /// <summary>
        /// Mock for IHubContext.Clients.All
        /// </summary>
        public Mock<THubResponses> ClientsAllMock { get; protected set; }

        /// <summary>
        /// Mock for IHubContext.Clients.AllExcpet()
        /// </summary>
        public Mock<THubResponses> ClientsAllExceptMock { get; protected set; }

        /// <summary>
        /// Mock for IHubContext.Clients.Client()
        /// </summary>
        public Mock<THubResponses> ClientsClientMock { get; protected set; }

        /// <summary>
        /// Mock for IHubContext.Clients.Clients()
        /// </summary>
        public Mock<THubResponses> ClientsClientsMock { get; protected set; }

        /// <summary>
        /// Mock for IHubContext.Clients.Group()
        /// </summary>
        public Mock<THubResponses> ClientsGroupMock { get; protected set; }

        /// <summary>
        /// Mock for IHubContext.Clients.GroupExcept()
        /// </summary>
        public Mock<THubResponses> ClientsGroupExceptMock { get; protected set; }

        /// <summary>
        /// Mock for IHubContext.Clients.Groups()
        /// </summary>
        public Mock<THubResponses> ClientsGroupsMock { get; protected set; }

        /// <summary>
        /// Mock for IHubContext.Clients.User()
        /// </summary>
        public Mock<THubResponses> ClientsUserMock { get; protected set; }

        /// <summary>
        /// Mock for IHubContext.Clients.Users()
        /// </summary>
        public Mock<THubResponses> ClientsUsersMock { get; protected set; }

        /// <summary>
        /// During object creation, set up on mocks is done
        /// </summary>
        public UnitTestingSupportForIHubContext()
        {
            base.SetUp();
            _setUpClientsMock();
            _setUpHubContextMock();
        }

        private void _setUpHubContextMock()
        {
            HubContextMock = new Mock<IHubContext<THub, THubResponses>>();
            HubContextMock
                .Setup(x => x.Groups)
                .Returns(GroupsMock.Object);
            HubContextMock
                .Setup(x => x.Clients)
                .Returns(ClientsMock.Object);
        }

        private void _setUpClientsMock()
        {
            ClientsMock = new Mock<IHubClients<THubResponses>>();
            _setUpClientsAll();
            _setUpClientsAllExcept();
            _setUpClientsClient();
            _setUpClientsClients();
            _setUpClientsGroup();
            _setUpClientsGroupExcept();
            _setUpClientsGroups();
            _setUpClientsUser();
        }

        private void _setUpClientsAll()
        {
            ClientsAllMock = _getHubResponosesMock();
            ClientsMock
                .Setup(x => x.All)
                .Returns(ClientsAllMock.Object);
        }

        private void _setUpClientsAllExcept()
        {
            ClientsAllExceptMock = _getHubResponosesMock();
            ClientsMock
                .Setup(x => x.AllExcept(It.IsAny<IReadOnlyList<string>>()))
                .Returns(ClientsAllExceptMock.Object);
        }

        private void _setUpClientsClient()
        {
            ClientsClientMock = _getHubResponosesMock();
            ClientsMock
                .Setup(x => x.Client(It.IsAny<string>()))
                .Returns(ClientsClientMock.Object);
        }

        private void _setUpClientsClients()
        {
            ClientsClientsMock = _getHubResponosesMock();
            ClientsMock
                .Setup(x => x.Clients(It.IsAny<IReadOnlyList<string>>()))
                .Returns(ClientsClientsMock.Object);
        }

        private void _setUpClientsGroup()
        {
            ClientsGroupMock = _getHubResponosesMock();
            ClientsMock
                .Setup(x => x.Group(It.IsAny<string>()))
                .Returns(ClientsGroupMock.Object);
        }

        private void _setUpClientsGroupExcept()
        {
            ClientsGroupExceptMock = _getHubResponosesMock();
            ClientsMock
                .Setup(x => x.GroupExcept(It.IsAny<string>(), It.IsAny<IReadOnlyList<string>>()))
                .Returns(ClientsGroupExceptMock.Object);
        }

        private void _setUpClientsGroups()
        {
            ClientsGroupsMock = _getHubResponosesMock();
            ClientsMock
                .Setup(x => x.Groups(It.IsAny<IReadOnlyList<string>>()))
                .Returns(ClientsGroupsMock.Object);
        }

        private void _setUpClientsUser()
        {
            ClientsUserMock = _getHubResponosesMock();
            ClientsMock
                .Setup(x => x.User(It.IsAny<string>()))
                .Returns(ClientsUserMock.Object);
        }

        private void _setUpClientsUsers()
        {
            ClientsUsersMock = _getHubResponosesMock();
            ClientsMock
                .Setup(x => x.Users(It.IsAny<IReadOnlyList<string>>()))
                .Returns(ClientsUsersMock.Object);
        }

        private Mock<THubResponses> _getHubResponosesMock()
        {
            return new Mock<THubResponses>();
        }
    }
}
