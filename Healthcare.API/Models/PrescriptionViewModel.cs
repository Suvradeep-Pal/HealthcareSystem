namespace Healthcare.API.Models
{
    public class PrescriptionViewModel
    {
        public int Id { get; set; }

        public int? PId { get; set; }
        public string? PatientName { get; set; }

        public int? DId { get; set; }

        public string? DName { get; set; }

        public string? Symptoms { get; set; }

        public string? Medicine { get; set; }
    }
}
