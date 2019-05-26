﻿using System;

namespace GoodMarket.Domain
{
    /// <summary>
    /// Связь заказ-продукт
    /// </summary>
    public class OrderProduct
    {
        public int OrderId { get; set; }
        public int ProductId { get; set; }

        public Order Order { get; set; }
        public Product Product { get; set; }
    }
}
