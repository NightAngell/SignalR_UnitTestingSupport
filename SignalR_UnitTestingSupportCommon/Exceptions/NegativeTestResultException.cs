using System;
using System.Collections.Generic;
using System.Text;

namespace SignalR_UnitTestingSupportCommon.Exceptions
{
    /// <summary>
    /// Exception which should be used only as test fail notification
    /// </summary>
    public class NegativeTestResultException : Exception
    {
        #pragma warning disable CS1591

        public NegativeTestResultException() : base() { }

        public NegativeTestResultException(string message) : base(message) { }

        public NegativeTestResultException(string message, Exception innerException)
       
        : base (message, innerException) { }

        #pragma warning restore CS1591
    }
}
