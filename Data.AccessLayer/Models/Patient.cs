using System;
using System.Collections.Generic;

namespace Data.AccessLayer.Models;

public partial class Patient
{
    public int Id { get; set; }

    public string First_Name { get; set; } = null!;

    public string Last_Name { get; set; } = null!;

    public DateTime Date_Of_Birth { get; set; }

    public string? Gender { get; set; }

    public string? Address { get; set; }

    public string Phone { get; set; } = null!;

    public DateTime? DateCreated { get; set; }

    public int? UserCreated { get; set; }

    public DateTime? DateUpdated { get; set; }

    public int? UserUpdated { get; set; }

    //public virtual ICollection<Prescription> Prescriptions { get; set; } = new List<Prescription>();
}
