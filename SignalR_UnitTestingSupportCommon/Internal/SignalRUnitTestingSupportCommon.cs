using Microsoft.AspNetCore.SignalR;
using Moq;
using SignalR_UnitTestingSupportCommon.Interfaces;
using System.Threading;

namespace SignalR_UnitTestingSupportCommon.Internal
{
    /// <summary>
    /// Internal class which provide common features for SignalR Unit testing support
    /// </summary>
    public abstract class SignalRUnitTestingSupportCommon
    {
        /// <summary>
        /// Mock for Hub.Groups 
        /// </summary>
        public Mock<IGroupManager> GroupsMock { get; internal set; }

        /// <summary>
        /// Only for internal classes implementation. Do not use it in tests directly.
        /// </summary>
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual void SetUp()
        {
            GroupsMock = new Mock<IGroupManager>();
        }

        /// <summary>
        /// Verify somebody added to group (Hub.Groups.AddToGroupAsync)
        /// </summary>
        /// <param name="times">For example: Times.Once(). Remember to call it, cause Times.Once throw error</param>
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

        /// <summary>
        /// Verify somebody added to group (Hub.Groups.AddToGroupAsync)
        /// </summary>
        /// <param name="times">For example: Times.Once(). Remember to call it, cause Times.Once throw error</param>
        /// <param name="groupName">Name of the group</param>
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

        /// <summary>
        /// Verify somebody added to group (Hub.Groups.AddToGroupAsync)
        /// </summary>
        /// <param name="times">For example: Times.Once(). Remember to call it, cause Times.Once throw error</param>
        /// <param name="groupName">Name of the group</param>
        /// <param name="connectionId">Hub.Context.ConnectionId</param>
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

        /// <summary>
        /// Verify somebody added to group (Hub.Groups.AddToGroupAsync)
        /// </summary>
        /// <param name="times">For example: Times.Once(). Remember to call it, cause Times.Once throw error</param>
        /// <param name="connectionId">Hub.Context.ConnectionId</param>
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

        /// <summary>
        /// Verify somebody removed from group (Hub.Groups.RemoveFromGroupAsync)
        /// </summary>
        /// <param name="times">For example: Times.Once(). Remember to call it, cause Times.Once throw error</param>
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

        /// <summary>
        /// Verify somebody removed from group (Hub.Groups.RemoveFromGroupAsync)
        /// </summary>
        /// <param name="times">For example: Times.Once(). Remember to call it, cause Times.Once throw error</param>
        /// <param name="groupName">Name of the group</param>
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

        /// <summary>
        /// Verify somebody removed from group (Hub.Groups.RemoveFromGroupAsync)
        /// </summary>
        /// <param name="times">For example: Times.Once(). Remember to call it, cause Times.Once throw error</param>
        /// <param name="groupName">Name of the group</param>
        /// <param name="connectionId">Hub.Context.ConnectionId</param>
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

        /// <summary>
        /// Verify somebody removed from group (Hub.Groups.RemoveFromGroupAsync)
        /// </summary>
        /// <param name="times">For example: Times.Once(). Remember to call it, cause Times.Once throw error</param>
        /// <param name="connectionId">Hub.Context.ConnectionId</param>
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
    }
}
