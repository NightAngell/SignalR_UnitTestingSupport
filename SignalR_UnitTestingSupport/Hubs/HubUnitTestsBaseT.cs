using Microsoft.AspNetCore.SignalR;
using Moq;
using NUnit.Framework;
using SignalR_UnitTestingSupportCommon.Hubs;
using SignalR_UnitTestingSupportCommon.Hubs.Internal;
using SignalR_UnitTestingSupportCommon.Interfaces;
using System;
using System.Collections.Generic;

namespace SignalR_UnitTestingSupport.Hubs
{
    public class HubUnitTestsBase<TIHubResponses> : HubUnitTestsBaseCommon , IHubUnitTestsBase<TIHubResponses>
        where TIHubResponses : class
    {
        readonly HubUnitTestsSupport<TIHubResponses> _commonSupport = new HubUnitTestsSupport<TIHubResponses>();
        public Mock<IHubCallerClients<TIHubResponses>> ClientsMock => _commonSupport.ClientsMock;

        public Mock<TIHubResponses> ClientsAllMock => _commonSupport.ClientsAllMock;
        public Mock<TIHubResponses> ClientsAllExceptMock => _commonSupport.ClientsAllExceptMock;
        public Mock<TIHubResponses> ClientsCallerMock => _commonSupport.ClientsCallerMock;
        public Mock<TIHubResponses> ClientsClientMock => _commonSupport.ClientsCallerMock;
        public Mock<TIHubResponses> ClientsClientsMock => _commonSupport.ClientsClientsMock;
        public Mock<TIHubResponses> ClientsGroupMock => _commonSupport.ClientsGroupMock;
        public Mock<TIHubResponses> ClientsGroupExceptMock => _commonSupport.ClientsGroupExceptMock;
        public Mock<TIHubResponses> ClientsGroupsMock => _commonSupport.ClientsGroupsMock;
        public Mock<TIHubResponses> ClientsOthersMock => _commonSupport.ClientsOthersMock;
        public Mock<TIHubResponses> ClientsOthersInGroupMock => _commonSupport.ClientsOthersInGroupMock;
        public Mock<TIHubResponses> ClientsUserMock => _commonSupport.ClientsUserMock;
        public Mock<TIHubResponses> ClientsUsersMock => _commonSupport.ClientsUsersMock;

        [SetUp]
        public void BaseSetUp()
        {
            _commonSupport.SetUp();        
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
