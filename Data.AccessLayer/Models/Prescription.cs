using System;
using System.Collections.Generic;

namespace Data.AccessLayer.Models;

public partial class Prescription
{
    public int Id { get; set; }

    public int? P_ID { get; set; }

    public int? D_ID { get; set; }

    public string D_Name { get; set; } = null!;

    public string Symptoms { get; set; } = null!;

    public string Medicine { get; set; } = null!;

    public DateTime? DateCreated { get; set; }

    public int? UserCreated { get; set; }

    public DateTime? DateUpdated { get; set; }

    public int? UserUpdated { get; set; }

    public bool Status { get; set; } = true;

    //public virtual Doctor? DIdNavigation { get; set; }

    //public virtual Patient? PIdNavigation { get; set; }
}
