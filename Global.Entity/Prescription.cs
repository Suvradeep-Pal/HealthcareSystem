using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Global.Entity
{
    public class Prescription
    {
        public int Id { get; set; }

        public int? PId { get; set; }
        public string? PatientName { get; set; }

        public int? DId { get; set; }

        public string? DName { get; set; }

        public string? Symptoms { get; set; }

        public string? Medicine { get; set; }

        public DateTime? DateCreated { get; set; }

        public int? UserCreated { get; set; }

        public DateTime? DateUpdated { get; set; }

        public int? UserUpdated { get; set; }

        public bool Status { get; set; }
    }
}
