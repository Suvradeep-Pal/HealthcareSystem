using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace Healthcare.UI.Models
{
    public class PrescriptionViewModel
    {
        public int Id { get; set; }

        public int? PId { get; set; }
        
        public string? PatientName { get; set; }

        public int? DId { get; set; }
        
        public string? DName { get; set; }

        [Required(ErrorMessage = "Mention the Symtom!")]

        public string? Symptoms { get; set; }

        [Required(ErrorMessage = "Please provide Medicine name!")]

        public string? Medicine { get; set; }

        [Required(ErrorMessage = "Please enter Doctor Name!")]

        public List<SelectListItem> DDLDoctor { get; set; }

        [Required(ErrorMessage = "Please enter Patient Name!")]

        public List<SelectListItem> DDLPatient { get; set; }
    }
}
