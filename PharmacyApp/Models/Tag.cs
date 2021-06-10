using System;
using System.Collections.Generic;

#nullable disable

namespace PharmacyApp.Models
{
    public partial class Tag
    {
        public Tag()
        {
            MedToTags = new HashSet<MedToTag>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<MedToTag> MedToTags { get; set; }
    }
}
