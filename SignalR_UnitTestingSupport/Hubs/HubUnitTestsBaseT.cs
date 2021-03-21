using NUnit.Framework;
using SignalR_UnitTestingSupportCommon.Hubs;

namespace SignalR_UnitTestingSupport.Hubs
{
    /// <summary>
    /// Base class which provide support for Hub&lt;T&gt; testing
    /// </summary>
    /// <typeparam name="TIHubResponses">Interface which is used in Hub&lt;T&gt; as T</typeparam>
#pragma warning disable SA1649 // File name should match first type name
    public abstract class HubUnitTestsBase<TIHubResponses> : HubUnitTestsSupport<TIHubResponses>
#pragma warning restore SA1649 // File name should match first type name
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
