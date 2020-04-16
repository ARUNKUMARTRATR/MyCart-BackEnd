using System;
using System.Collections.Generic;

namespace Experion.MyCart.Data.Entities
{
    public partial class Catogory
    {
        public Catogory()
        {
            Products = new HashSet<Products>();
        }

        public int CatogoryId { get; set; }
        public string Catogories { get; set; }

        public virtual ICollection<Products> Products { get; set; }
    }
}
