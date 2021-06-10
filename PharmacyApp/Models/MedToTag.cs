using System;
using System.Collections.Generic;

#nullable disable

namespace PharmacyApp.Models
{
    public partial class MedToTag
    {
        public int Id { get; set; }
        public int? MedicineId { get; set; }
        public int? TagId { get; set; }

        public virtual Medicine Medicine { get; set; }
        public virtual Tag Tag { get; set; }
    }
}
