using System;
using System.Collections.Generic;

namespace WebHoaqua.Models
{
    public partial class ExportBill
    {
        public ExportBill()
        {
            DetailExportBills = new HashSet<DetailExportBill>();
        }

        public int Id { get; set; }
        public DateTime? ExportDate { get; set; }
        public string? StaffId { get; set; }
        public int? CustomerId { get; set; }
        public double? TotalPrice { get; set; }
        public string? Note { get; set; }

        public virtual Customer? Customer { get; set; }
        public virtual Account? Staff { get; set; }
        public virtual ICollection<DetailExportBill> DetailExportBills { get; set; }
    }
}
