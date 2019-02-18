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
        Mock<HubCallerContext> ContextMock { get; }
        Mock<IGroupManager> GroupsMock { get; }
        Dictionary<object, object> ItemsFake { get; }

        void VerifyContextItemsContainKeyValuePair(object key, object value);
        void VerifySomebodyAddedToGroup(Times times);
        void VerifySomebodyAddedToGroup(Times times, string groupName);
        void VerifySomebodyAddedToGroup(Times times, string groupName, string connectionId);
        void VerifySomebodyRemovedFromGroup(Times times);
        void VerifySomebodyRemovedFromGroup(Times times, string groupName);
        void VerifySomebodyRemovedFromGroup(Times times, string groupName, string connectionId);
        void VerifyUserAddedToGroupByConnId(Times times, string connectionId);
        void VerifyUserRemovedFromGroupByConnId(Times times, string connectionId);
    }
}