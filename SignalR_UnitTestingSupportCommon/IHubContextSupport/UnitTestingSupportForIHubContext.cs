using Microsoft.AspNetCore.SignalR;
using Moq;
using SignalR_UnitTestingSupportCommon.Internal;
using System.Collections.Generic;

namespace SignalR_UnitTestingSupportCommon.IHubContextSupport
{
    /// <summary>
    /// It provide preconfigured IHubContext mock and other mocks required to testing.
    /// </summary>
    public class UnitTestingSupportForIHubContext<THub> : SignalRUnitTestingSupportCommon
        where THub: Hub
    {
        /// <summary>
        /// Mock for Microsoft.AspNetCore.SignalR.IHubContext&lt;THub&gt;
        /// </summary>
        public Mock<IHubContext<THub>> HubContextMock { get; protected set; }

        /// <summary>
        /// Mock for IHubContext.Clients
        /// </summary>
        public Mock<IHubClients> ClientsMock { get; protected set; }

        /// <summary>
        /// Mock for IHubContext.Clients.All
        /// </summary>
        public Mock<IClientProxy> ClientsAllMock { get; protected set; }

        /// <summary>
        /// Mock for IHubContext.Clients.AllExcpet()
        /// </summary>
        public Mock<IClientProxy> ClientsAllExceptMock { get; protected set; }

        /// <summary>
        /// Mock for IHubContext.Clients.Client()
        /// </summary>
        public Mock<IClientProxy> ClientsClientMock { get; protected set; }

        /// <summary>
        /// Mock for IHubContext.Clients.Clients()
        /// </summary>
        public Mock<IClientProxy> ClientsClientsMock { get; protected set; }

        /// <summary>
        /// Mock for IHubContext.Clients.Group()
        /// </summary>
        public Mock<IClientProxy> ClientsGroupMock { get; protected set; }

        /// <summary>
        /// Mock for IHubContext.Clients.GroupExcept()
        /// </summary>
        public Mock<IClientProxy> ClientsGroupExceptMock { get; protected set; }

        /// <summary>
        /// Mock for IHubContext.Clients.Groups()
        /// </summary>
        public Mock<IClientProxy> ClientsGroupsMock { get; protected set; }

        /// <summary>
        /// Mock for IHubContext.Clients.User()
        /// </summary>
        public Mock<IClientProxy> ClientsUserMock { get; protected set; }

        /// <summary>
        /// Mock for IHubContext.Clients.Users()
        /// </summary>
        public Mock<IClientProxy> ClientsUsersMock { get; protected set; }

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
            HubContextMock = new Mock<IHubContext<THub>>();
            HubContextMock
                .Setup(x => x.Groups)
                .Returns(GroupsMock.Object);
            HubContextMock
                .Setup(x => x.Clients)
                .Returns(ClientsMock.Object);
        }

        private void _setUpClientsMock()
        {
            ClientsMock = new Mock<IHubClients>();
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
            ClientsAllMock = _getClientProxyMock();
            ClientsMock
                .Setup(x => x.All)
                .Returns(ClientsAllMock.Object);
        }

        private void _setUpClientsAllExcept()
        {
            ClientsAllExceptMock = _getClientProxyMock();
            ClientsMock
                .Setup(x => x.AllExcept(It.IsAny<IReadOnlyList<string>>()))
                .Returns(ClientsAllExceptMock.Object);
        }

        private void _setUpClientsClient()
        {
            ClientsClientMock = _getClientProxyMock();
            ClientsMock
                .Setup(x => x.Client(It.IsAny<string>()))
                .Returns(ClientsClientMock.Object);
        }

        private void _setUpClientsClients()
        {
            ClientsClientsMock = _getClientProxyMock();
            ClientsMock
                .Setup(x => x.Clients(It.IsAny<IReadOnlyList<string>>()))
                .Returns(ClientsClientsMock.Object);
        }

        private void _setUpClientsGroup()
        {
            ClientsGroupMock = _getClientProxyMock();
            ClientsMock
                .Setup(x => x.Group(It.IsAny<string>()))
                .Returns(ClientsGroupMock.Object);
        }

        private void _setUpClientsGroupExcept()
        {
            ClientsGroupExceptMock = _getClientProxyMock();
            ClientsMock
                .Setup(x => x.GroupExcept(It.IsAny<string>(), It.IsAny<IReadOnlyList<string>>()))
                .Returns(ClientsGroupExceptMock.Object);
        }

        private void _setUpClientsGroups()
        {
            ClientsGroupsMock = _getClientProxyMock();
            ClientsMock
                .Setup(x => x.Groups(It.IsAny<IReadOnlyList<string>>()))
                .Returns(ClientsGroupsMock.Object);
        }

        private void _setUpClientsUser()
        {
            ClientsUserMock = _getClientProxyMock();
            ClientsMock
                .Setup(x => x.User(It.IsAny<string>()))
                .Returns(ClientsUserMock.Object);
        }

        private void _setUpClientsUsers()
        {
            ClientsUsersMock = _getClientProxyMock();
            ClientsMock
                .Setup(x => x.Users(It.IsAny<IReadOnlyList<string>>()))
                .Returns(ClientsUsersMock.Object);
        }

        private Mock<IClientProxy> _getClientProxyMock()
        {
            return new Mock<IClientProxy>();
        }
    }
}
