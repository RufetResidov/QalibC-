using System;
using System.Collections.Generic;

#nullable disable

namespace PharmacyApp.Models
{
    public partial class Firm
    {
        public Firm()
        {
            Medicines = new HashSet<Medicine>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Medicine> Medicines { get; set; }

        public static implicit operator Firm(string v)
        {
            throw new NotImplementedException();
        }
    }
}
