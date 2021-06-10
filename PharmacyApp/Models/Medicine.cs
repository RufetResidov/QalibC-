using System;
using System.Collections.Generic;

#nullable disable

namespace PharmacyApp.Models
{
    public partial class Medicine
    {
        public Medicine()
        {
            MedToTags = new HashSet<MedToTag>();
            OrdersItems = new HashSet<OrdersItem>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public decimal? Price { get; set; }
        public int? Count { get; set; }
        public DateTime? ProductionDate { get; set; }
        public DateTime? ExpireDate { get; set; }
        public string Description { get; set; }
        public int? FirmId { get; set; }
        public bool? IsReceipt { get; set; }

        public virtual Firm Firm { get; set; }
        public virtual ICollection<MedToTag> MedToTags { get; set; }
        public virtual ICollection<OrdersItem> OrdersItems { get; set; }
    }
}
