using Microsoft.VisualStudio.TestTools.UnitTesting;
using SignalR_UnitTestingSupportCommon.Hubs;

namespace SignalR_UnitTestingSupportMSTest.Hubs
{
    /// <summary>
    /// Base class which provide support for Hub&lt;T&gt; testing
    /// </summary>
    /// <typeparam name="TIHubResponses">Interface which is used in Hub&lt;T&gt; as T</typeparam>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1649:File name should match first type name", Justification = "Legacy name")]
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
