using System.ComponentModel.DataAnnotations;

namespace Healthcare.API.Models
{
    public class PatientViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please Enter First Name!")]
        public string FirstName { get; set; } = null!;

        [Required(ErrorMessage = "Please Enter Last Name!")]
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
        public string Phone { get; set; } = null!;
    }
}
