using Microsoft.AspNetCore.SignalR;
using Moq;
using NUnit.Framework;
using SignalR_UnitTestingSupport.Hubs.Internal;
using System;
using System.Collections.Generic;

namespace SignalR_UnitTestingSupport.Hubs
{
    public abstract class HubUnitTestsBase : HubUnitTestsBaseCommon
    {
        public Mock<IHubCallerClients> ClientsMock { get; private set; }

        public Mock<IClientProxy> ClientsAllMock { get; private set; }
        public Mock<IClientProxy> ClientsAllExceptMock { get; private set; }
        public Mock<IClientProxy> ClientsCallerMock { get; private set; }
        public Mock<IClientProxy> ClientsClientMock { get; private set; }
        public Mock<IClientProxy> ClientsClientsMock { get; private set; }
        public Mock<IClientProxy> ClientsGroupMock { get; private set; }
        public Mock<IClientProxy> ClientsGroupExceptMock { get; private set; }
        public Mock<IClientProxy> ClientsGroupsMock { get; private set; }
        public Mock<IClientProxy> ClientsOthersMock { get; private set; }
        public Mock<IClientProxy> ClientsOthersInGroupMock { get; private set; }
        public Mock<IClientProxy> ClientsUserMock { get; private set; }
        public Mock<IClientProxy> ClientsUsersMock { get; private set; }

        [SetUp]
        public void HubUnitTestSupportSetUp()
        {
            _setUpContext();
            _setUpGroups();
            _setUpClients();
        }

        /// <summary>
        /// Assign to hub Clients, Context and Groups mocks objects.
        /// </summary>
        public void AssignToHubRequiredProperties(Hub hub)
        {
            if (hub == null)
                throw new ArgumentNullException("Hub not initialized");

            hub.Clients = ClientsMock.Object;
            hub.Context = ContextMock.Object;
            hub.Groups = GroupsMock.Object;
        }

        internal override void SetUpClients()
        {
            ClientsMock = new Mock<IHubCallerClients>();
        }

        internal override void SetUpClientsAll()
        {
            ClientsAllMock = new Mock<IClientProxy>();
            ClientsMock
                .Setup(x => x.All)
                .Returns(ClientsAllMock.Object);
        }

        internal override void SetUpClientsAllExcept()
        {
            ClientsAllExceptMock = new Mock<IClientProxy>();
            ClientsMock
                .Setup(x => x.AllExcept(It.IsAny<IReadOnlyList<string>>()))
                .Returns(ClientsAllExceptMock.Object);
        }

        internal override void SetUpClientsCaller()
        {
            ClientsCallerMock = new Mock<IClientProxy>();
            ClientsMock
                .Setup(x => x.Caller)
                .Returns(ClientsCallerMock.Object);
        }

        internal override void SetUpClientsClient()
        {
            ClientsClientMock = new Mock<IClientProxy>();
            ClientsMock
                .Setup(x => x.Client(It.IsAny<string>()))
                .Returns(ClientsClientMock.Object);
        }

        internal override void SetUpClientsClients()
        {
            ClientsClientsMock = new Mock<IClientProxy>();
            ClientsMock
                .Setup(x => x.Clients(It.IsAny<IReadOnlyList<string>>()))
                .Returns(ClientsClientsMock.Object);
        }

        internal override void SetUpClientsGroup()
        {
            ClientsGroupMock = new Mock<IClientProxy>();
            ClientsMock
                .Setup(x => x.Group(It.IsAny<string>()))
                .Returns(ClientsGroupMock.Object);
        }

        internal override void SetUpClientsGroupExcept()
        {
            ClientsGroupExceptMock = new Mock<IClientProxy>();
            ClientsMock
                .Setup(x => x.GroupExcept(It.IsAny<string>(), It.IsAny<IReadOnlyList<string>>()))
                .Returns(ClientsGroupExceptMock.Object);
        }

        internal override void SetUpClientsGroups()
        {
            ClientsGroupsMock = new Mock<IClientProxy>();
            ClientsMock
                .Setup(x => x.Groups(It.IsAny<IReadOnlyList<string>>()))
                .Returns(ClientsGroupsMock.Object);
        }

        internal override void SetUpClientsOthersMock()
        {
            ClientsOthersMock = new Mock<IClientProxy>();
            ClientsMock
                .Setup(x => x.Others)
                .Returns(ClientsOthersMock.Object);
        }

        internal override void SetUpClientsOthersInGroup()
        {
            ClientsOthersInGroupMock = new Mock<IClientProxy>();
            ClientsMock
                .Setup(x => x.OthersInGroup(It.IsAny<string>()))
                .Returns(ClientsOthersInGroupMock.Object);
        }

        internal override void SetUpClientsUser()
        {
            ClientsUserMock = new Mock<IClientProxy>();
            ClientsMock
                .Setup(x => x.User(It.IsAny<string>()))
                .Returns(ClientsUserMock.Object);
        }

        internal override void SetUpClientsUsers()
        {
            ClientsUsersMock = new Mock<IClientProxy>();
            ClientsMock
                .Setup(x => x.Users(It.IsAny<IReadOnlyList<string>>()))
                .Returns(ClientsUsersMock.Object);
        }
    }
}
