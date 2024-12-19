using System;
using System.Collections.Generic;

namespace WebHoaqua.Models
{
    public partial class Category
    {
        public Category()
        {
            Products = new HashSet<Product>();
        }

        public int CateId { get; set; }
        public string? CategoryName { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
