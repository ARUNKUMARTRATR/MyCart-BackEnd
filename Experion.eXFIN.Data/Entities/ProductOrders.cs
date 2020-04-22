using System;
using System.Collections.Generic;

namespace Experion.MyCart.Data.Entities
{
    public partial class ProductOrders
    {
        public int Id { get; set; }
        public double TotalPrice { get; set; }
        public string ProductId { get; set; }
        public int userId{ get; set; }

        public string FName { get; set; }
        public string LName { get; set; }
        public string Dob { get; set; }
        public string Add1 { get; set; }
        public string Add2 { get; set; }
        public string State { get; set; }
        public string Mobile { get; set; }
        public int ZipCode { get; set; }
        public bool Terms { get; set; }

    }
}
