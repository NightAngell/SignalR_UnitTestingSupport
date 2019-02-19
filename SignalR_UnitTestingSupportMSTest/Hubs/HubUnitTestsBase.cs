using Microsoft.VisualStudio.TestTools.UnitTesting;
using SignalR_UnitTestingSupportCommon.Hubs;

namespace SignalR_UnitTestingSupportMSTest.Hubs
{
    /// <summary>
    /// Base class which provide support for Hub testing.
    /// </summary>
    public abstract class HubUnitTestsBase : HubUnitTestsSupport
    {
        /// <summary>
        /// Only MSTest Should Call it. Do not call it directly.
        /// </summary>
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        [TestInitialize]
        public void HubUnitTestSupportSetUp()
        {
            SetUp();
        }
    }
}
