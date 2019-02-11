using Microsoft.AspNetCore.SignalR;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace SignalR_UnitTestingSupport.Hubs
{
    public abstract class HubUnitTestsBase<TIHubResponses> where TIHubResponses : class
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

            _clientsAllMock = new Mock<TIHubResponses>();
            _clientsMock
                .Setup(x => x.All)
                .Returns(_clientsAllMock.Object);

            _clientsAllExceptMock = new Mock<TIHubResponses>();
            _clientsMock
                .Setup(x => x.AllExcept(It.IsAny<IReadOnlyList<string>>()))
                .Returns(_clientsAllExceptMock.Object);

            _clientsCallerMock = new Mock<TIHubResponses>();
            _clientsMock
                .Setup(x => x.Caller)
                .Returns(_clientsCallerMock.Object);

            _clientsClientMock = new Mock<TIHubResponses>();
            _clientsMock
                .Setup(x => x.Client(It.IsAny<string>()))
                .Returns(_clientsClientMock.Object);

            _clientsClientsMock = new Mock<TIHubResponses>();
            _clientsMock
                .Setup(x => x.Clients(It.IsAny<IReadOnlyList<string>>()))
                .Returns(_clientsClientsMock.Object);

            _clientsGroupMock = new Mock<TIHubResponses>();
            _clientsMock
                .Setup(x => x.Group(It.IsAny<string>()))
                .Returns(_clientsGroupMock.Object);

            _clientsGroupExceptMock = new Mock<TIHubResponses>();
            _clientsMock
                .Setup(x => x.GroupExcept(It.IsAny<string>(), It.IsAny<IReadOnlyList<string>>()))
                .Returns(_clientsGroupExceptMock.Object);

            _clientsGroupsMock = new Mock<TIHubResponses>();
            _clientsMock
                .Setup(x => x.Groups(It.IsAny<IReadOnlyList<string>>()))
                .Returns(_clientsGroupsMock.Object);

            _clientsOthersMock = new Mock<TIHubResponses>();
            _clientsMock
                .Setup(x => x.Others)
                .Returns(_clientsOthersMock.Object);

            _clientsOthersInGroupMock = new Mock<TIHubResponses>();
            _clientsMock
                .Setup(x => x.OthersInGroup(It.IsAny<string>()))
                .Returns(_clientsOthersInGroupMock.Object);

            _clientsUserMock = new Mock<TIHubResponses>();
            _clientsMock
                .Setup(x => x.User(It.IsAny<string>()))
                .Returns(_clientsUserMock.Object);

            _clientsUsersMock = new Mock<TIHubResponses>();
            _clientsMock
                .Setup(x => x.Users(It.IsAny<IReadOnlyList<string>>()))
                .Returns(_clientsUsersMock.Object);
        }

        /// <summary>
        /// Assign to hub Clients, Context and Groups mocks objects.
        /// </summary>
        protected void _assignToHubRequiredProperties<T>(T hub) where T : Hub<TIHubResponses>
        {
            if (hub == null)
                throw new ArgumentNullException("Hub not initialized");

            hub.Clients = _clientsMock.Object;
            hub.Context = _contextMock.Object;
            hub.Groups = _groupsMock.Object;
        }

        protected void _verifySomebodyAddedToGroup(Times times)
        {
            _groupsMock
                .Verify(x => x.AddToGroupAsync(
                    It.IsAny<string>(),
                    It.IsAny<string>(),
                    It.IsAny<CancellationToken>()),
                    times
                );
        }

        protected void _verifySomebodyAddedToGroup(Times times, string groupName)
        {
            _groupsMock
                .Verify(x => x.AddToGroupAsync(
                    It.IsAny<string>(),
                    groupName,
                    It.IsAny<CancellationToken>()),
                    times
                );
        }

        protected void _verifySomebodyAddedToGroup(Times times, string groupName, string connectionId)
        {
            _groupsMock
                .Verify(x => x.AddToGroupAsync(
                    connectionId,
                    groupName,
                    It.IsAny<CancellationToken>()),
                    times
                );
        }

        protected void _verifySomebodyRemovedFromGroup(Times times)
        {
            _groupsMock
                .Verify(x => x.RemoveFromGroupAsync(
                    It.IsAny<string>(),
                    It.IsAny<string>(),
                    It.IsAny<CancellationToken>()),
                    times
                );
        }

        protected void _verifySomebodyRemovedFromGroup(Times times, string groupName)
        {
            _groupsMock
                .Verify(x => x.RemoveFromGroupAsync(
                    It.IsAny<string>(),
                    groupName,
                    It.IsAny<CancellationToken>()),
                    times
                );
        }

        protected void _verifySomebodyRemovedFromGroup(Times times, string groupName, string connectionId)
        {
            _groupsMock
                .Verify(x => x.RemoveFromGroupAsync(
                    connectionId,
                    groupName,
                    It.IsAny<CancellationToken>()),
                    times
                );
        }

        protected void _verifyContextItemsContainKeyValuePair(object key, object value)
        {
            try
            {
                Assert.IsTrue(_itemsFake.ContainsKey(key));
                Assert.IsTrue(_itemsFake.ContainsValue(value));
            }
            catch(AssertionException)
            {
                throw new AssertionException($"Context items don`t contain that key-value pair: {key}-{value}");
            }
            
        }
    }
}
