using System;
using System.Collections.Generic;

namespace WebHoaqua.Models
{
    public partial class Suplier
    {
        public Suplier()
        {
            ImportBills = new HashSet<ImportBill>();
        }

        public int SuplierId { get; set; }
        public string? SuplierName { get; set; }
        public string? Address { get; set; }
        public string? Phone { get; set; }

        public virtual ICollection<ImportBill> ImportBills { get; set; }
    }
}
