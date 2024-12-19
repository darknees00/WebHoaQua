using System;
using System.Collections.Generic;

namespace WebHoaqua.Models
{
    public partial class DetailImportBill
    {
        public int ImportId { get; set; }
        public int ProductId { get; set; }
        public double? Quantity { get; set; }
        public double? PriceAitem { get; set; }
        public double? TotalPrice { get; set; }

        public virtual ImportBill Import { get; set; } = null!;
        public virtual Product Product { get; set; } = null!;
    }
}
