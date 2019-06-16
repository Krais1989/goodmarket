using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace GoodMarket.Application.Exceptions
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
