using System;
using System.Collections.Generic;
using System.Text;

namespace SignalR_UnitTestingSupportCommon.Exceptions
{
    public class NegativeTestResultException : Exception
    {
        public NegativeTestResultException() : base() { }
      
        public NegativeTestResultException(string message) : base(message) { }
       
        public NegativeTestResultException(string message, Exception innerException)
        : base (message, innerException) { }
    }
}
