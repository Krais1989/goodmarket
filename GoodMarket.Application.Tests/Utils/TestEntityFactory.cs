using GoodMarket.Domain;
using System;

namespace GoodMarket.Application.Tests
{
    public class TestEntityFactory
    {
        public virtual object Create(Type type)
        {
            return Activator.CreateInstance(type);
        }
    }

    public class TestEntityFactory<T> : TestEntityFactory
    {
        public virtual T Create()
        {
            return (T)Create(typeof(T));
        }
    }

    public class TestUserFactory : TestEntityFactory<User>
    {
        public override User Create()
        {
            var newUser = base.Create();
            newUser.Id = 0;
            newUser.Email = "User_" + 0;
            newUser.Details = new PersonDetails()
            {
                Name = "Vasya №" + 0,
                Age = 20 + 0
            };
            return newUser;
        }
    }
    public class TestProductFactory : TestEntityFactory<Product> { }
}
