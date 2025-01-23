using System;
using System.Collections.Generic;

namespace Data.AccessLayer.Models;

public partial class Doctor
{
    public int Id { get; set; }

    public string First_Name { get; set; } = null!;

    public string Last_Name { get; set; } = null!;

    public string? Gender { get; set; }

    public string? Specialization { get; set; }

    public DateTime? DateCreated { get; set; }

    public int? UserCreated { get; set; }

    public DateTime? DateUpdated { get; set; }

    public int? UserUpdated { get; set; }

    //public virtual ICollection<Prescription> Prescriptions { get; set; } = new List<Prescription>();
}
