using Microsoft.VisualStudio.TestTools.UnitTesting;
using SignalR_UnitTestingSupportCommon.Hubs;

namespace SignalR_UnitTestingSupportMSTest.Hubs
{
    public class HubUnitTestsBase<TIHubResponses> : HubUnitTestsSupport<TIHubResponses>
        where TIHubResponses : class
    {
        /// <summary>
        /// Only MSTest Should Call it. Do not call it directly.
        /// </summary>
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        [TestInitialize]
        public void BaseSetUp()
        {
            SetUp();
        }
    }
}
