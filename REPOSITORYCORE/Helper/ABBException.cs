using System;
using Microsoft.Extensions.Logging;

namespace ABB.Core.Helper
{
    public class ABBException: Exception
    {
        public ABBException()
        {
        }

        public ABBException(string message, ILogger logger) : base(message)
        {
            logger.LogError(message);
        }

        public ABBException(Exception innerException,string message, ILogger logger) : base(message, innerException)
        {
            logger.LogError(innerException, message);
        }
    }
}