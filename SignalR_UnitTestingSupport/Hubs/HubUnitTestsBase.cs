using NUnit.Framework;
using SignalR_UnitTestingSupportCommon.Hubs;

namespace SignalR_UnitTestingSupport.Hubs
{
    public abstract class HubUnitTestsBase : HubUnitTestsSupport
    {
        /// <summary>
        /// Only NUnit Should Call it. Do not call it directly.
        /// </summary>
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        [SetUp]
        public void HubUnitTestSupportSetUp()
        {
            SetUp();
        }
    }
}
