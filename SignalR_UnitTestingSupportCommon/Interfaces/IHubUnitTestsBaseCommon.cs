using System.Collections.Generic;
using Microsoft.AspNetCore.SignalR;
using Moq;

namespace SignalR_UnitTestingSupportCommon.Interfaces
{
    /// <summary>
    /// To be sure we implement all common features for SignalR Unit Testing Support classes
    /// </summary>
    public interface IHubUnitTestsBaseCommon
    {
        /// <summary>
        /// Gets mock for Hub.Context
        /// </summary>
        Mock<HubCallerContext> ContextMock { get; }

        /// <summary>
        /// Gets mock for Hub.Groups 
        /// </summary>
        Mock<IGroupManager> GroupsMock { get; }

        /// <summary>
        /// Gets fake for Hub.Contex.Items
        /// </summary>
        Dictionary<object, object> ItemsFake { get; }

        /// <summary>
        /// Verify if Hub.Context.Items containt key-value pair
        /// </summary>
        /// <param name="key">Dictionary key</param>
        /// <param name="value">Dictionary value</param>
        void VerifyContextItemsContainKeyValuePair(object key, object value);

        /// <summary>
        /// Verify somebody added to group (Hub.Groups.AddToGroupAsync)
        /// </summary>
        /// <param name="times">For example: Times.Once(). Remember to call it, cause Times.Once throw error</param>
        void VerifySomebodyAddedToGroup(Times times);

        /// <summary>
        /// Verify somebody added to group (Hub.Groups.AddToGroupAsync)
        /// </summary>
        /// <param name="times">For example: Times.Once(). Remember to call it, cause Times.Once throw error</param>
        /// <param name="groupName">Name of the group</param>
        void VerifySomebodyAddedToGroup(Times times, string groupName);

        /// <summary>
        /// Verify somebody added to group (Hub.Groups.AddToGroupAsync)
        /// </summary>
        /// <param name="times">For example: Times.Once(). Remember to call it, cause Times.Once throw error</param>
        /// <param name="groupName">Name of the group</param>
        /// <param name="connectionId">Hub.Context.ConnectionId</param>
        void VerifySomebodyAddedToGroup(Times times, string groupName, string connectionId);

        /// <summary>
        /// Verify somebody removed from group (Hub.Groups.RemoveFromGroupAsync)
        /// </summary>
        /// <param name="times">For example: Times.Once(). Remember to call it, cause Times.Once throw error</param>
        void VerifySomebodyRemovedFromGroup(Times times);

        /// <summary>
        /// Verify somebody removed from group (Hub.Groups.RemoveFromGroupAsync)
        /// </summary>
        /// <param name="times">For example: Times.Once(). Remember to call it, cause Times.Once throw error</param>
        /// <param name="groupName">Name of the group</param>
        void VerifySomebodyRemovedFromGroup(Times times, string groupName);

        /// <summary>
        /// Verify somebody removed from group (Hub.Groups.RemoveFromGroupAsync)
        /// </summary>
        /// <param name="times">For example: Times.Once(). Remember to call it, cause Times.Once throw error</param>
        /// <param name="groupName">Name of the group</param>
        /// <param name="connectionId">Hub.Context.ConnectionId</param>
        void VerifySomebodyRemovedFromGroup(Times times, string groupName, string connectionId);

        /// <summary>
        /// Verify somebody added to group (Hub.Groups.AddToGroupAsync)
        /// </summary>
        /// <param name="times">For example: Times.Once(). Remember to call it, cause Times.Once throw error</param>
        /// <param name="connectionId">Hub.Context.ConnectionId</param>
        void VerifyUserAddedToGroupByConnId(Times times, string connectionId);

        /// <summary>
        /// Verify somebody removed from group (Hub.Groups.RemoveFromGroupAsync)
        /// </summary>
        /// <param name="times">For example: Times.Once(). Remember to call it, cause Times.Once throw error</param>
        /// <param name="connectionId">Hub.Context.ConnectionId</param>
        void VerifyUserRemovedFromGroupByConnId(Times times, string connectionId);

        /// <summary>
        /// Set Up mocks. Prepared for testing engine.
        /// </summary>
        void SetUp();
    }
}