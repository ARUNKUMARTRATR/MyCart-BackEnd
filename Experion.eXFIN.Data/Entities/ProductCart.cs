using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Experion.MyCart.Data.Entities
{
    public partial class ProductCart
    {
        [Key]
        public int Id { get; set; }
        public int UserId { get; set; }
        public string CartProductId { get; set; }
        public int ProductCount { get; set; }

        public virtual Products IdNavigation { get; set; }
        public virtual Users User { get; set; }
    }
}
