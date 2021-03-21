using System.Collections.Generic;
using Microsoft.AspNetCore.SignalR;
using Moq;
using SignalR_UnitTestingSupportCommon.IHubContextSupport.Internal;

namespace SignalR_UnitTestingSupportCommon.IHubContextSupport
{
    /// <summary>
    /// It provide preconfigured IHubContext mock and other mocks required to testing.
    /// </summary>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1649:File name should match first type name", Justification = "I want to avoid breaking change by accident")]
    public class UnitTestingSupportForIHubContext<THub, THubResponses> : UnitTestingSupportForIHubContextCommon
        where THubResponses : class
        where THub : Hub<THubResponses>
    {
        /// <summary>
        /// Gets or sets mock for Microsoft.AspNetCore.SignalR.IHubContext&lt;THub, THubResponses&gt;
        /// </summary>
        public Mock<IHubContext<THub, THubResponses>> IHubContextMock { get; protected set; }

        /// <summary>
        /// Gets or sets mock for IHubContext.Clients
        /// </summary>
        public Mock<IHubClients<THubResponses>> ClientsMock { get; protected set; }

        /// <summary>
        /// Gets or sets mock for IHubContext.Clients.All
        /// </summary>
        public Mock<THubResponses> ClientsAllMock { get; protected set; }

        /// <summary>
        /// Gets or sets mock for IHubContext.Clients.AllExcpet()
        /// </summary>
        public Mock<THubResponses> ClientsAllExceptMock { get; protected set; }

        /// <summary>
        /// Gets or sets mock for IHubContext.Clients.Client()
        /// </summary>
        public Mock<THubResponses> ClientsClientMock { get; protected set; }

        /// <summary>
        /// Gets or sets mock for IHubContext.Clients.Clients()
        /// </summary>
        public Mock<THubResponses> ClientsClientsMock { get; protected set; }

        /// <summary>
        /// Gets or sets mock for IHubContext.Clients.Group()
        /// </summary>
        public Mock<THubResponses> ClientsGroupMock { get; protected set; }

        /// <summary>
        /// Gets or sets mock for IHubContext.Clients.GroupExcept()
        /// </summary>
        public Mock<THubResponses> ClientsGroupExceptMock { get; protected set; }

        /// <summary>
        /// Gets or sets mock for IHubContext.Clients.Groups()
        /// </summary>
        public Mock<THubResponses> ClientsGroupsMock { get; protected set; }

        /// <summary>
        /// Gets or sets mock for IHubContext.Clients.User()
        /// </summary>
        public Mock<THubResponses> ClientsUserMock { get; protected set; }

        /// <summary>
        /// Gets or sets mock for IHubContext.Clients.Users()
        /// </summary>
        public Mock<THubResponses> ClientsUsersMock { get; protected set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="UnitTestingSupportForIHubContext{THub, THubResponses}"/> class.
        /// During object creation, set up on mocks is done
        /// </summary>
        public UnitTestingSupportForIHubContext()
        {
            SetUp();
            _setUpHubContextMock();
        }

        private void _setUpHubContextMock()
        {
            IHubContextMock = new Mock<IHubContext<THub, THubResponses>>();
            IHubContextMock
                .Setup(x => x.Groups)
                .Returns(GroupsMock.Object);
            IHubContextMock
                .Setup(x => x.Clients)
                .Returns(ClientsMock.Object);
        }

        internal override void SetUpClients()
        {
            ClientsMock = new Mock<IHubClients<THubResponses>>();
        }

        internal override void SetUpClientsAll()
        {
            ClientsAllMock = _getHubResponosesMock();
            ClientsMock
                .Setup(x => x.All)
                .Returns(ClientsAllMock.Object);
        }

        internal override void SetUpClientsAllExcept()
        {
            ClientsAllExceptMock = _getHubResponosesMock();
            ClientsMock
                .Setup(x => x.AllExcept(It.IsAny<IReadOnlyList<string>>()))
                .Returns(ClientsAllExceptMock.Object);
        }

        internal override void SetUpClientsClient()
        {
            ClientsClientMock = _getHubResponosesMock();
            ClientsMock
                .Setup(x => x.Client(It.IsAny<string>()))
                .Returns(ClientsClientMock.Object);
        }

        internal override void SetUpClientsClients()
        {
            ClientsClientsMock = _getHubResponosesMock();
            ClientsMock
                .Setup(x => x.Clients(It.IsAny<IReadOnlyList<string>>()))
                .Returns(ClientsClientsMock.Object);
        }

        internal override void SetUpClientsGroup()
        {
            ClientsGroupMock = _getHubResponosesMock();
            ClientsMock
                .Setup(x => x.Group(It.IsAny<string>()))
                .Returns(ClientsGroupMock.Object);
        }

        internal override void SetUpClientsGroupExcept()
        {
            ClientsGroupExceptMock = _getHubResponosesMock();
            ClientsMock
                .Setup(x => x.GroupExcept(It.IsAny<string>(), It.IsAny<IReadOnlyList<string>>()))
                .Returns(ClientsGroupExceptMock.Object);
        }

        internal override void SetUpClientsGroups()
        {
            ClientsGroupsMock = _getHubResponosesMock();
            ClientsMock
                .Setup(x => x.Groups(It.IsAny<IReadOnlyList<string>>()))
                .Returns(ClientsGroupsMock.Object);
        }

        internal override void SetUpClientsUser()
        {
            ClientsUserMock = _getHubResponosesMock();
            ClientsMock
                .Setup(x => x.User(It.IsAny<string>()))
                .Returns(ClientsUserMock.Object);
        }

        internal override void SetUpClientsUsers()
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
