using System;
using System.Collections.Generic;

#nullable disable

namespace PharmacyApp.Models
{
    public partial class OrdersItem
    {
        public int Id { get; set; }
        public int? MedicineId { get; set; }
        public int? Quantity { get; set; }
        public int? OrderId { get; set; }
        public decimal? ItemPrice { get; set; }

        public virtual Medicine Medicine { get; set; }
        public virtual Order Order { get; set; }
    }
}
