using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Global.Entity
{
    public class Patient
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please Enter First Name!")]
        [RegularExpression("^[a-zA-Z\\s]+$", ErrorMessage = "Name can only contain letters and spaces.")]
        public string FirstName { get; set; } = null!;

        [Required(ErrorMessage = "Please Enter Last Name!")]
        [RegularExpression("^[a-zA-Z\\s]+$", ErrorMessage = "Name can only contain letters and spaces.")]

        public string LastName { get; set; } = null!;

        [Required(ErrorMessage = "Please Enter Date of Birth!")]
        [Display(Name = "Date of Birth")]
        [DataType(DataType.Date)]

        public DateTime DateOfBirth { get; set; }

        [Required(ErrorMessage = "Please Choose Gender!")]

        public string? Gender { get; set; }

        [Required(ErrorMessage = "Please Enter Address!")]

        public string? Address { get; set; }

        [Required(ErrorMessage = "Please Enter Phone Number!")]
        [Display(Name = "Phone Number")]
        [Phone]
        [RegularExpression("^[0-9]+$", ErrorMessage = "Phone number can only contain numeric values.")]

        public string Phone { get; set; } = null!;

        public DateTime? DateCreated { get; set; }

        public int? UserCreated { get; set; }

        public DateTime? DateUpdated { get; set; }

        public int? UserUpdated { get; set; }


        public bool Status { get; set; }

        //public virtual ICollection<Prescription> Prescriptions { get; set; } = new List<Prescription>();
    }
}
