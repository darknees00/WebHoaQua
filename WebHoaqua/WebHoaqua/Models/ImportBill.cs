using System;
using System.Collections.Generic;

namespace WebHoaqua.Models
{
    public partial class ImportBill
    {
        public ImportBill()
        {
            DetailImportBills = new HashSet<DetailImportBill>();
        }

        public int Id { get; set; }
        public DateTime? ImportDate { get; set; }
        public string? StaffId { get; set; }
        public int? SuplierId { get; set; }
        public double? TotalPrice { get; set; }

        public virtual Account? Staff { get; set; }
        public virtual Suplier? Suplier { get; set; }
        public virtual ICollection<DetailImportBill> DetailImportBills { get; set; }
    }
}
