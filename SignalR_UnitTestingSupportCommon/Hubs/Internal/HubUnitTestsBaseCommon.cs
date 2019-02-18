using Microsoft.AspNetCore.SignalR;
using Moq;
using SignalR_UnitTestingSupportCommon.Exceptions;
using SignalR_UnitTestingSupportCommon.Interfaces;
using System.Collections.Generic;
using System.Threading;

namespace SignalR_UnitTestingSupportCommon.Hubs.Internal
{
    /// <summary>
    /// Internal class which provide common part for all unit testing support classes.
    /// </summary>
    public abstract class HubUnitTestsBaseCommon : IHubUnitTestsBaseCommon
    {
        public Dictionary<object, object> ItemsFake { get; internal set; }
        public Mock<HubCallerContext> ContextMock { get; internal set; }
        public Mock<IGroupManager> GroupsMock { get; internal set; }

        /// <summary>
        /// Only for internal base classes implementation. Do not use it in tests directly.
        /// </summary>
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual void SetUp()
        {
            _setUpContext();
            _setUpGroups();
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

        private void _setUpGroups()
        {
            GroupsMock = new Mock<IGroupManager>();
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

        internal abstract void SetUpClientsUsers();
        internal abstract void SetUpClientsUser();
        internal abstract void SetUpClientsOthersInGroup();
        internal abstract void SetUpClientsOthersMock();
        internal abstract void SetUpClientsGroups();
        internal abstract void SetUpClientsGroupExcept();
        internal abstract void SetUpClientsGroup();
        internal abstract void SetUpClientsClients();
        internal abstract void SetUpClientsClient();
        internal abstract void SetUpClientsCaller();
        internal abstract void SetUpClientsAllExcept();
        internal abstract void SetUpClientsAll();
        internal abstract void SetUpClients();

        public void VerifySomebodyAddedToGroup(Times times)
        {
            GroupsMock
                .Verify(x => x.AddToGroupAsync(
                    It.IsAny<string>(),
                    It.IsAny<string>(),
                    It.IsAny<CancellationToken>()),
                    times
                );
        }

        public void VerifySomebodyAddedToGroup(Times times, string groupName)
        {
            GroupsMock
                .Verify(x => x.AddToGroupAsync(
                    It.IsAny<string>(),
                    groupName,
                    It.IsAny<CancellationToken>()),
                    times
                );
        }

        public void VerifySomebodyAddedToGroup(Times times, string groupName, string connectionId)
        {
            GroupsMock
                .Verify(x => x.AddToGroupAsync(
                    connectionId,
                    groupName,
                    It.IsAny<CancellationToken>()),
                    times
                );
        }

        public void VerifyUserAddedToGroupByConnId(Times times, string connectionId)
        {
            GroupsMock
                .Verify(x => x.AddToGroupAsync(
                    connectionId,
                    It.IsAny<string>(),
                    It.IsAny<CancellationToken>()),
                    times
                );
        }

        public void VerifySomebodyRemovedFromGroup(Times times)
        {
            GroupsMock
                .Verify(x => x.RemoveFromGroupAsync(
                    It.IsAny<string>(),
                    It.IsAny<string>(),
                    It.IsAny<CancellationToken>()),
                    times
                );
        }

        public void VerifySomebodyRemovedFromGroup(Times times, string groupName)
        {
            GroupsMock
                .Verify(x => x.RemoveFromGroupAsync(
                    It.IsAny<string>(),
                    groupName,
                    It.IsAny<CancellationToken>()),
                    times
                );
        }

        public void VerifySomebodyRemovedFromGroup(Times times, string groupName, string connectionId)
        {
            GroupsMock
                .Verify(x => x.RemoveFromGroupAsync(
                    connectionId,
                    groupName,
                    It.IsAny<CancellationToken>()),
                    times
                );
        }

        public void VerifyUserRemovedFromGroupByConnId(Times times, string connectionId)
        {
            GroupsMock
                .Verify(x => x.RemoveFromGroupAsync(
                    connectionId,
                    It.IsAny<string>(),
                    It.IsAny<CancellationToken>()),
                    times
                );
        }

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
