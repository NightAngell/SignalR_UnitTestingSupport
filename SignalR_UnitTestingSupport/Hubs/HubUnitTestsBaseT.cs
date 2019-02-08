using Microsoft.AspNetCore.SignalR;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace SignalR_UnitTestingSupport.Hubs
{
    abstract class HubUnitTestsBase<TIHubResponses> where TIHubResponses : class
    {
        protected Mock<HubCallerContext> _contextMock;
        protected Mock<IGroupManager> _groupsMock;
        protected Mock<IHubCallerClients<TIHubResponses>> _clientsMock;

        protected Mock<TIHubResponses> _clientsAllMock;
        protected Mock<TIHubResponses> _clientsAllExceptMock;
        protected Mock<TIHubResponses> _clientsCallerMock;
        protected Mock<TIHubResponses> _clientsClientMock;
        protected Mock<TIHubResponses> _clientsClientsMock;
        protected Mock<TIHubResponses> _clientsGroupMock;
        protected Mock<TIHubResponses> _clientsGroupExceptMock;
        protected Mock<TIHubResponses> _clientsGroupsMock;
        protected Mock<TIHubResponses> _clientsOthersMock;
        protected Mock<TIHubResponses> _clientsOthersInGroupMock;
        protected Mock<TIHubResponses> _clientsUserMock;
        protected Mock<TIHubResponses> _clientsUsersMock;

        protected Dictionary<object, object> _itemsFake;

        [SetUp]
        public void BaseSetUp()
        {
            _setUpContext();
            _setUpGroups();
            _setUpClients();            
        }

        private void _setUpContext()
        {
           _contextMock = new Mock<HubCallerContext>();
           _itemsFake = new Dictionary<object, object>();
           _contextMock.Setup(x => x.Items).Returns(_itemsFake);
        }

        private void _setUpGroups()
        {
            _groupsMock = new Mock<IGroupManager>();
        }

        private void _setUpClients()
        {
            _clientsMock = new Mock<IHubCallerClients<TIHubResponses>>();
            _clientsMock
                .Setup(x => x.All)
                .Returns(_clientsAllMock.Object);
            _clientsMock
                .Setup(x => x.AllExcept(It.IsAny<IReadOnlyList<string>>()))
                .Returns(_clientsAllExceptMock.Object);
            _clientsMock
                .Setup(x => x.Caller)
                .Returns(_clientsCallerMock.Object);
            _clientsMock
                .Setup(x => x.Client(It.IsAny<string>()))
                .Returns(_clientsClientMock.Object);
            _clientsMock
                .Setup(x => x.Clients(It.IsAny<IReadOnlyList<string>>()))
                .Returns(_clientsClientsMock.Object);
            _clientsMock
                .Setup(x => x.Group(It.IsAny<string>()))
                .Returns(_clientsGroupMock.Object);
            _clientsMock
                .Setup(x => x.GroupExcept(It.IsAny<string>(), It.IsAny<IReadOnlyList<string>>()))
                .Returns(_clientsGroupExceptMock.Object);
            _clientsMock
                .Setup(x => x.Groups(It.IsAny<IReadOnlyList<string>>()))
                .Returns(_clientsGroupsMock.Object);
            _clientsMock
                .Setup(x => x.Others)
                .Returns(_clientsOthersMock.Object);
            _clientsMock
                .Setup(x => x.OthersInGroup(It.IsAny<string>()))
                .Returns(_clientsOthersInGroupMock.Object);
            _clientsMock
                .Setup(x => x.User(It.IsAny<string>()))
                .Returns(_clientsUserMock.Object);
            _clientsMock
                .Setup(x => x.Users(It.IsAny<IReadOnlyList<string>>()))
                .Returns(_clientsUsersMock.Object);
        }
    }
}
