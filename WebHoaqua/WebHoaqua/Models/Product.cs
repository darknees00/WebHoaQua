using System;
using System.Collections.Generic;

namespace WebHoaqua.Models
{
    public partial class Product
    {
        public Product()
        {
            DetailExportBills = new HashSet<DetailExportBill>();
            DetailImportBills = new HashSet<DetailImportBill>();
            OrderDetais = new HashSet<OrderDetai>();
        }

        public int ProductId { get; set; }
        public string? ProductName { get; set; }
        public double? PriceImport { get; set; }
        public double? PriceSale { get; set; }
        public double? Quantity { get; set; }
        public int? CategoryId { get; set; }
        public string? Image { get; set; }
        public int? StatusId { get; set; }

        public virtual Category? Category { get; set; }
        public virtual Status? Status { get; set; }
        public virtual ICollection<DetailExportBill> DetailExportBills { get; set; }
        public virtual ICollection<DetailImportBill> DetailImportBills { get; set; }
        public virtual ICollection<OrderDetai> OrderDetais { get; set; }
    }
}
