using System.Collections.Generic;
using Microsoft.AspNetCore.SignalR;
using Moq;
using SignalR_UnitTestingSupportCommon.IHubContextSupport.Internal;

namespace SignalR_UnitTestingSupportCommon.IHubContextSupport
{
    /// <summary>
    /// It provide preconfigured IHubContext mock and other mocks required to testing.
    /// </summary>
    public class UnitTestingSupportForIHubContext<THub> : UnitTestingSupportForIHubContextCommon
        where THub : Hub
    {
        /// <summary>
        /// Gets or sets mock for Microsoft.AspNetCore.SignalR.IHubContext&lt;THub&gt;
        /// </summary>
        public Mock<IHubContext<THub>> IHubContextMock { get; protected set; }

        /// <summary>
        /// Gets or sets mock for IHubContext.Clients
        /// </summary>
        public Mock<IHubClients> ClientsMock { get; protected set; }

        /// <summary>
        /// Gets or sets mock for IHubContext.Clients.All
        /// </summary>
        public Mock<IClientProxy> ClientsAllMock { get; protected set; }

        /// <summary>
        /// Gets or sets mock for IHubContext.Clients.AllExcpet()
        /// </summary>
        public Mock<IClientProxy> ClientsAllExceptMock { get; protected set; }

        /// <summary>
        /// Gets or sets mock for IHubContext.Clients.Client()
        /// </summary>
        public Mock<IClientProxy> ClientsClientMock { get; protected set; }

        /// <summary>
        /// Gets or sets mock for IHubContext.Clients.Clients()
        /// </summary>
        public Mock<IClientProxy> ClientsClientsMock { get; protected set; }

        /// <summary>
        /// Gets or sets mock for IHubContext.Clients.Group()
        /// </summary>
        public Mock<IClientProxy> ClientsGroupMock { get; protected set; }

        /// <summary>
        /// Gets or sets mock for IHubContext.Clients.GroupExcept()
        /// </summary>
        public Mock<IClientProxy> ClientsGroupExceptMock { get; protected set; }

        /// <summary>
        /// Gets or sets mock for IHubContext.Clients.Groups()
        /// </summary>
        public Mock<IClientProxy> ClientsGroupsMock { get; protected set; }

        /// <summary>
        /// Gets or sets mock for IHubContext.Clients.User()
        /// </summary>
        public Mock<IClientProxy> ClientsUserMock { get; protected set; }

        /// <summary>
        /// Gets or sets mock for IHubContext.Clients.Users()
        /// </summary>
        public Mock<IClientProxy> ClientsUsersMock { get; protected set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="UnitTestingSupportForIHubContext{THub}"/> class.
        /// During object creation, it setup all required mocks
        /// </summary>
        public UnitTestingSupportForIHubContext()
        {
#pragma warning disable SA1100 // Do not prefix calls with base unless local implementation exists
            base.SetUp();
#pragma warning restore SA1100 // Do not prefix calls with base unless local implementation exists
            _setUpHubContextMock();
        }

        private void _setUpHubContextMock()
        {
            IHubContextMock = new Mock<IHubContext<THub>>();
            IHubContextMock
                .Setup(x => x.Groups)
                .Returns(GroupsMock.Object);
            IHubContextMock
                .Setup(x => x.Clients)
                .Returns(ClientsMock.Object);
        }

        internal override void SetUpClientsAll()
        {
            ClientsAllMock = _getClientProxyMock();
            ClientsMock
                .Setup(x => x.All)
                .Returns(ClientsAllMock.Object);
        }

        internal override void SetUpClients()
        {
            ClientsMock = new Mock<IHubClients>();
        }

        internal override void SetUpClientsAllExcept()
        {
            ClientsAllExceptMock = _getClientProxyMock();
            ClientsMock
                .Setup(x => x.AllExcept(It.IsAny<IReadOnlyList<string>>()))
                .Returns(ClientsAllExceptMock.Object);
        }

        internal override void SetUpClientsClient()
        {
            ClientsClientMock = _getClientProxyMock();
            ClientsMock
                .Setup(x => x.Client(It.IsAny<string>()))
                .Returns(ClientsClientMock.Object);
        }

        internal override void SetUpClientsClients()
        {
            ClientsClientsMock = _getClientProxyMock();
            ClientsMock
                .Setup(x => x.Clients(It.IsAny<IReadOnlyList<string>>()))
                .Returns(ClientsClientsMock.Object);
        }

        internal override void SetUpClientsGroup()
        {
            ClientsGroupMock = _getClientProxyMock();
            ClientsMock
                .Setup(x => x.Group(It.IsAny<string>()))
                .Returns(ClientsGroupMock.Object);
        }

        internal override void SetUpClientsGroupExcept()
        {
            ClientsGroupExceptMock = _getClientProxyMock();
            ClientsMock
                .Setup(x => x.GroupExcept(It.IsAny<string>(), It.IsAny<IReadOnlyList<string>>()))
                .Returns(ClientsGroupExceptMock.Object);
        }

        internal override void SetUpClientsGroups()
        {
            ClientsGroupsMock = _getClientProxyMock();
            ClientsMock
                .Setup(x => x.Groups(It.IsAny<IReadOnlyList<string>>()))
                .Returns(ClientsGroupsMock.Object);
        }

        internal override void SetUpClientsUser()
        {
            ClientsUserMock = _getClientProxyMock();
            ClientsMock
                .Setup(x => x.User(It.IsAny<string>()))
                .Returns(ClientsUserMock.Object);
        }

        internal override void SetUpClientsUsers()
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
