using System;

namespace GoodMarket.Application.Exceptions
{
    public class EntityNotFoundException<T> : Exception
    {
        public EntityNotFoundException(string message) : base(message)
        {
        }
    }

}
