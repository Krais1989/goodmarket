﻿using GoodMarket.Domain;
using GoodMarket.Persistence;

namespace GoodMarket.Application.CQRS
{
    public class CustomerCreateCommandHandler : BaseCreateCommandHandler<Customer>
    {
        public CustomerCreateCommandHandler(GoodMarketDb db) : base(db) { }
    }
}
