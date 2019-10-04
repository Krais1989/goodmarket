using System;
using System.Runtime.Serialization;
using Microsoft.AspNetCore.Http;

namespace GoodMarket.Application.Exceptions.Basics
{
    /// <summary>
    /// Базовый класс 
    /// </summary>
    public class GMException : Exception, IGMException
    {
        public virtual int ResponseCode => StatusCodes.Status200OK;

        public GMException()
        {
        }

        public GMException(string message) : base(message)
        {
        }

        public GMException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected GMException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

    }
}
