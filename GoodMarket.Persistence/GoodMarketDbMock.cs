using GoodMarket.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace GoodMarket.Persistence
{
    public static class GoodMarketDbMock
    {
        public static void Populate(this GoodMarketDb db)
        {
            PopulateUsers(db);
            PopulateProducts(db);
            PopulateCustomers(db);
        }

        private static void PopulateProducts(GoodMarketDb db)
        {
            int prodCound = 10;
            for (int i = 0; i < prodCound; i++)
            {
                db.Products.Add(new Product()
                {
                    Title = $"Product {i}"
                });
            }
            db.SaveChanges();
        }

        private static void PopulateUsers(GoodMarketDb db)
        {
            int usersCount = 10;
            for (int i = 0; i < usersCount; i++)
            {
                db.Users.Add(new User()
                {
                    Email = $"User_{i}@gmail.com",
                    Password = $"pass{i}",
                    Role = 0,
                    Details = new PersonDetails()
                    {
                        Name = $"Name{i}",
                        Age = 20 + i,
                        Gender = PersonDetails.EGender.Male,
                        PhoneNumber = $"8-800-{i}"
                    }
                });
            }
            db.SaveChanges();
        }

        private static void PopulateCustomers(GoodMarketDb db)
        {
            int count = 10;
            for (int i = 0; i < count; i++)
            {
                db.Customers.Add(new Customer()
                {
                    Email = $"Customer_{i}@gmail.com",
                    Details = new PersonDetails()
                    {
                        Name = $"Name{i}",
                        Age = 20 + i,
                        Gender = PersonDetails.EGender.Male,
                        PhoneNumber = $"8-800-{i}"
                    },
                    Cart = new Cart()
                    {
                        Records = new Dictionary<int, int>()
                        {
                            { 0,2 },
                            {1,1 },
                            {2,1 },
                            {3,2 },
                        }
                    }

                });
            }
            db.SaveChanges();
        }
    }
}
