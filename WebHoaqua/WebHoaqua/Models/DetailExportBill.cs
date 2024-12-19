using System;
using System.Collections.Generic;

namespace WebHoaqua.Models
{
    public partial class DetailExportBill
    {
        public int ExportId { get; set; }
        public int ProductId { get; set; }
        public double? Quantity { get; set; }
        public double? TotalPrice { get; set; }
        public double? Discount { get; set; }

        public virtual ExportBill Export { get; set; } = null!;
        public virtual Product Product { get; set; } = null!;
    }
}
