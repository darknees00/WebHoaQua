using System;
using System.Collections.Generic;

namespace WebHoaqua.Models
{
    public partial class Staff
    {
        public string StaffId { get; set; } = null!;
        public string? StaffName { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string? Gender { get; set; }
        public string? Address { get; set; }
        public string? Note { get; set; }

        public virtual Account StaffNavigation { get; set; } = null!;
    }
}
