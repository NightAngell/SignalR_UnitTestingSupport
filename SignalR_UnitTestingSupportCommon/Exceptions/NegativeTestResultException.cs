using System;

namespace SignalR_UnitTestingSupportCommon.Exceptions
{
    /// <summary>
    /// Exception which should be used only as test fail notification
    /// </summary>
    public class NegativeTestResultException : Exception
    {
        public NegativeTestResultException() : base()
        {
        }

        public NegativeTestResultException(string message) : base(message)
        {
        }

        public NegativeTestResultException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
