namespace Healthcare.API.Models
{
    public class DoctorViewModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = null!;

        public string LastName { get; set; } = null!;

        public string? Gender { get; set; }

        public string? Specialization { get; set; }
    }
}
