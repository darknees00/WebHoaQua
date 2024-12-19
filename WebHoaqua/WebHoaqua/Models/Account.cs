using System;
using System.Collections.Generic;

namespace WebHoaqua.Models
{
    public partial class Account
    {
        public Account()
        {
            ExportBills = new HashSet<ExportBill>();
            ImportBills = new HashSet<ImportBill>();
            Orders = new HashSet<Order>();
        }

        public string Username { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string Type { get; set; } = null!;
        public string Email { get; set; } = null!;

        public virtual ICollection<ExportBill> ExportBills { get; set; }
        public virtual ICollection<ImportBill> ImportBills { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
