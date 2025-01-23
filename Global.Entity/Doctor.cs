using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Global.Entity
{
    public class Doctor
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please Enter First Name!")]
        [RegularExpression("^[a-zA-Z\\s]+$", ErrorMessage = "Name can only contain letters and spaces.")]
        public string FirstName { get; set; } = null!;

        [Required(ErrorMessage = "Please Enter Last Name!")]
        [RegularExpression("^[a-zA-Z\\s]+$", ErrorMessage = "Name can only contain letters and spaces.")]

        public string LastName { get; set; } = null!;

        [Required(ErrorMessage = "Please Choose Gender!")]

        public string? Gender { get; set; }

        [Required(ErrorMessage = "Please Enter Specialization!")]

        public string? Specialization { get; set; }

        public DateTime? DateCreated { get; set; }

        public int? UserCreated { get; set; }

        public DateTime? DateUpdated { get; set; }

        public int? UserUpdated { get; set; }
    }
}
