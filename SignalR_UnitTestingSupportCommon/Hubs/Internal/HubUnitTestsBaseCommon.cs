using Microsoft.AspNetCore.SignalR;
using Moq;
using SignalR_UnitTestingSupportCommon.Exceptions;
using SignalR_UnitTestingSupportCommon.Interfaces;
using SignalR_UnitTestingSupportCommon.Internal;
using System.Collections.Generic;

namespace SignalR_UnitTestingSupportCommon.Hubs.Internal
{
    /// <summary>
    /// Internal class which provide common code for all unit testing support classes.
    /// </summary>
    public abstract class HubUnitTestsBaseCommon : SignalRUnitTestingSupportCommon, IHubUnitTestsBaseCommon
    {
        /// <summary>
        /// Fake for Hub.Contex.Items
        /// </summary>
        public Dictionary<object, object> ItemsFake { get; internal set; }

        /// <summary>
        /// Mock for Hub.Context
        /// </summary>
        public Mock<HubCallerContext> ContextMock { get; internal set; }

        /// <summary>
        /// Only for internal classes implementation. Do not use it in tests directly.
        /// </summary>
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public override void SetUp()
        {
            base.SetUp();
            _setUpContext();
            _setUpClients();
        }

        private void _setUpContext()
        {
            ContextMock = new Mock<HubCallerContext>();
            ItemsFake = new Dictionary<object, object>();
            ContextMock.Setup(x => x.Items).Returns(ItemsFake);

            string connId = System.Guid.NewGuid().ToString();
            ContextMock.Setup(x => x.ConnectionId).Returns(connId);
        }

        private void _setUpClients()
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

        internal abstract void SetUpClientsOthersInGroup();
        internal abstract void SetUpClientsOthersMock();
        internal abstract void SetUpClientsCaller();

        /// <summary>
        /// Verify if Hub.Context.Items containt key-value pair
        /// </summary>
        /// <param name="key">Dictionary key</param>
        /// <param name="value">Dictionary value</param>
        public void VerifyContextItemsContainKeyValuePair(object key, object value)
        {
            bool shouldThrowException = false;
            string exceptionMessage = $"Context items don`t contain that key-value pair: {key}-{value}. ";

            try
            {
                if (!ItemsFake.ContainsValue(value))
                {
                    shouldThrowException = true;
                    exceptionMessage = $"It don`t contain that value";
                }
                else
                {
                    exceptionMessage = $"It contain that value";
                }

                if (!ItemsFake.ContainsKey(key))
                {
                    shouldThrowException = true;
                    exceptionMessage = $" and It don`t contain that key";
                }
                else
                {
                    exceptionMessage = $" and It contain that key";
                }
            }
            catch (System.ArgumentNullException)
            {
                exceptionMessage = $" and key is null";
                throw new NegativeTestResultException($"{exceptionMessage}");
            }

            if (shouldThrowException) throw new NegativeTestResultException($"{exceptionMessage}");
        }
    }
}
