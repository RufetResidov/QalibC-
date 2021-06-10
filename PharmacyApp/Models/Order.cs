using System;
using System.Collections.Generic;

#nullable disable

namespace PharmacyApp.Models
{
    public partial class Order
    {
        public Order()
        {
            OrdersItems = new HashSet<OrdersItem>();
        }

        public int Id { get; set; }
        public decimal? TotalPrice { get; set; }
        public DateTime? PurchaseDate { get; set; }
        public int? WorkerId { get; set; }

        public virtual Worker Worker { get; set; }
        public virtual ICollection<OrdersItem> OrdersItems { get; set; }
    }
}
