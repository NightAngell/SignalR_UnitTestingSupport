using System;
using System.Collections.Generic;
using System.Text;

namespace SignalR_UnitTestingSupportCommon.Interfaces
{
    public interface ISetUpForUserAndEngine
    {
        /// <summary>
        /// Set Up object. Prepared for testing engine 
        /// or user which decided use class which implement that interfeca as object.
        /// </summary>
        void SetUp();
    }
}
