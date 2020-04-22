using System;
using System.Collections.Generic;

namespace Experion.MyCart.Data.Entities
{
    public partial class Users
    {
        public int UserId { get; set; }
        public string FName { get; set; }
        public string LName { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public bool? IsPremium { get; set; }
        public string MobileNo { get; set; }
        public string PhotoUrl { get; set; }
        public bool IsAdmin { get; set; }

    }
}
