using System;
using System.Collections.Generic;

namespace Experion.MyCart.Data.Entities
{
    public partial class ProductOrders
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public double Price { get; set; }
        public string ProductId { get; set; }
    }
}
