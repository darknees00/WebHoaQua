using System;
using System.Collections.Generic;

namespace WebHoaqua.Models
{
    public partial class Customer
    {
        public Customer()
        {
            ExportBills = new HashSet<ExportBill>();
        }

        public int CustomerId { get; set; }
        public string? CustomerName { get; set; }
        public string? State { get; set; }
        public string? Phone { get; set; }
        public string? Note { get; set; }

        public virtual ICollection<ExportBill> ExportBills { get; set; }
    }
}
