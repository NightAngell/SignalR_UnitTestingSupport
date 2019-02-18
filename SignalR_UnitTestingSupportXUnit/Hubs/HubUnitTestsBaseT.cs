using SignalR_UnitTestingSupportCommon.Hubs;
using System;

namespace SignalR_UnitTestingSupportXUnit.Hubs
{
    public class HubUnitTestsBase<TIHubResponses> : HubUnitTestsSupport<TIHubResponses>, IDisposable
        where TIHubResponses : class
    {
        public HubUnitTestsBase()
        {
            SetUp();
        }

        public virtual void Dispose()
        {
            //Nothing to dispose here
        }
    }
}
