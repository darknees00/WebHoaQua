using System;
using System.Collections.Generic;

namespace WebHoaqua.Models
{
    public partial class OrderDetai
    {
        public int Id { get; set; }
        public int? OrderId { get; set; }
        public int? SanphamId { get; set; }
        public int? Soluong { get; set; }
        public int? Tongtien { get; set; }

        public virtual Order? Order { get; set; }
        public virtual Product? Sanpham { get; set; }
    }
}
