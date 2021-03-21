using System;
using SignalR_UnitTestingSupportCommon.Hubs;

namespace SignalR_UnitTestingSupportXUnit.Hubs
{
    /// <summary>
    /// Base class which provide support for Hub testing.
    /// </summary>
    public abstract class HubUnitTestsBase : HubUnitTestsSupport, IDisposable
    {
        public HubUnitTestsBase()
        {
            SetUp();
        }

        /// <summary>
        /// Only xUnit should call this. Do not it directly.
        /// </summary>
        public virtual void Dispose()
        {
            // Nothing to dispose here
        }
    }
}
