using System;
using System.Collections.Generic;
using System.Text;

namespace GoodMarket.Application.Exceptions
{
    /// <summary>
    /// Интерфейс-метка кастомных исключений IGMException
    /// </summary>
    public interface IGMException
    {
        int ResponseCode { get; }
    }
}
