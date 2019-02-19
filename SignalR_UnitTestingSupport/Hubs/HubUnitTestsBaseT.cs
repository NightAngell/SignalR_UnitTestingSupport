using NUnit.Framework;
using SignalR_UnitTestingSupportCommon.Hubs;

namespace SignalR_UnitTestingSupport.Hubs
{
    /// <summary>
    /// Base class which provide support for Hub&lt;T&gt; testing
    /// </summary>
    /// <typeparam name="TIHubResponses">Interface which is used in Hub&lt;T&gt; as T</typeparam>
    public abstract class HubUnitTestsBase<TIHubResponses> : HubUnitTestsSupport<TIHubResponses>
        where TIHubResponses : class
    {
        /// <summary>
        /// Only NUnit Should Call it. Do not call it directly.
        /// </summary>
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        [SetUp]
        public void BaseSetUp()
        {
            SetUp();   
        }
    }
}
