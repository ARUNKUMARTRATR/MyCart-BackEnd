using System;
using System.Collections.Generic;
using System.Text;

namespace Experion.MyCart.Data.Model
{
    public class orderDto
    {
        public double TotalPrice { get; set; }
        public string ProductId { get; set; }
        public string FName { get; set; }
        public string LName { get; set; }
        public string Add1 { get; set; }
        public string Mobile { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        public string LaunchDate { get; set; }
        public string PhotoUrl { get; set; }
    }
}
