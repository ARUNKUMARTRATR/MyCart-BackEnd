using System;
using System.Collections.Generic;
using System.Text;

namespace Experion.MyCart.Data.Model
{
   public class ProductModel
    {
        public string ProductId { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public string LaunchDate { get; set; }
        public string PhotoUrl { get; set; }
        public bool IsAvailable { get; set; }
        public bool IsDeleted { get; set; }
        public string CatogoryName { get; set; }
    }
}
