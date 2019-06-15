using System;

namespace GoodMarket.Application.Exceptions
{
    /// <summary>
    /// Сущность уже имеется
    /// </summary>
    public class EntityAlreadyExistsException<T> : Exception
    {
    }

}
