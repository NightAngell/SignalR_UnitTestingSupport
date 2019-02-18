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
    public abstract class HubUnitTestsBase : HubUnitTestsBaseCommon, IHubUnitTestsBase
    {
        readonly HubUnitTestsSupport _commonSupport = new HubUnitTestsSupport();
        public Mock<IHubCallerClients> ClientsMock => _commonSupport.ClientsMock;

        public Mock<IClientProxy> ClientsAllMock => _commonSupport.ClientsAllMock;
        public Mock<IClientProxy> ClientsAllExceptMock => _commonSupport.ClientsAllExceptMock;
        public Mock<IClientProxy> ClientsCallerMock => _commonSupport.ClientsCallerMock;
        public Mock<IClientProxy> ClientsClientMock => _commonSupport.ClientsCallerMock;
        public Mock<IClientProxy> ClientsClientsMock => _commonSupport.ClientsClientsMock;
        public Mock<IClientProxy> ClientsGroupMock => _commonSupport.ClientsGroupMock;
        public Mock<IClientProxy> ClientsGroupExceptMock => _commonSupport.ClientsGroupExceptMock;
        public Mock<IClientProxy> ClientsGroupsMock => _commonSupport.ClientsGroupsMock;
        public Mock<IClientProxy> ClientsOthersMock => _commonSupport.ClientsOthersMock;
        public Mock<IClientProxy> ClientsOthersInGroupMock => _commonSupport.ClientsOthersInGroupMock;
        public Mock<IClientProxy> ClientsUserMock => _commonSupport.ClientsUserMock;
        public Mock<IClientProxy> ClientsUsersMock => _commonSupport.ClientsUsersMock;

        [SetUp]
        public void HubUnitTestSupportSetUp()
        {
            _commonSupport.SetUp();
        }

        /// <summary>
        /// Assign to hub Clients, Context and Groups mocks objects.
        /// </summary>
        public void AssignToHubRequiredProperties(Hub hub)
        {
            _commonSupport.AssignToHubRequiredProperties(hub);
        }
    }
}
