using System;
using SignalR_UnitTestingSupportCommon.Hubs;

namespace SignalR_UnitTestingSupportXUnit.Hubs
{
    public abstract class HubUnitTestsBase : HubUnitTestsSupport, IDisposable
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
