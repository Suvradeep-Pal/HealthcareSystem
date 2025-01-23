using Data.AccessLayer.Models;
using Microsoft.EntityFrameworkCore;

namespace Healthcare.API.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Prescription> Prescription { get; set; }
        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Patient>().HasData(
        //        new Patient
        //        {
        //            Id = 6,
        //            First_Name = "Aman",
        //            Last_Name = "Bhatt",
        //            Date_Of_Birth = new DateTime(1997, 02, 04),
        //            Gender = "M",
        //            Address = "Delhi",
        //            Phone = "8894121000",
        //            DateCreated = new DateTime(),
        //            UserCreated = null,
        //            DateUpdated = new DateTime(),
        //            UserUpdated = null
        //        },
        //        new Patient
        //        {
        //            Id = 7,
        //            First_Name = "Raman",
        //            Last_Name = "Gupta",
        //            Date_Of_Birth = new DateTime(1994, 06, 12),
        //            Gender = "M",
        //            Address = "Mumbai",
        //            Phone = "9045889744",
        //            DateCreated = new DateTime(),
        //            UserCreated = null,
        //            DateUpdated = new DateTime(),
        //            UserUpdated = null
        //        });

        //    modelBuilder.Entity<Doctor>().HasData(
        //        new Doctor
        //        {
        //            Id = 6,
        //            First_Name = "Dr. Ramesh",
        //            Last_Name = "Kurral",
        //            Gender = "M",
        //            Specialization = "Physio",
        //            DateCreated = new DateTime(),
        //            UserCreated = null,
        //            DateUpdated = new DateTime(),
        //            UserUpdated = null
        //        },
        //        new Doctor
        //        {
        //            Id = 7,
        //            First_Name = "Dr, Goutam",
        //            Last_Name = "Nath",
        //            Gender = "M",
        //            Specialization = "MD",
        //            DateCreated = new DateTime(),
        //            UserCreated = null,
        //            DateUpdated = new DateTime(),
        //            UserUpdated = null
        //        });
        //    modelBuilder.Entity<Prescription>().HasData(
        //        new Prescription
        //        {
        //            Id = 6,
        //            P_ID = 3,
        //            D_ID = 3,
        //            D_Name = "Dr. Sangita Chowdhury",
        //            Symptoms = "Gyano",
        //            Medicine = "zzzz",
        //            DateCreated = new DateTime(),
        //            UserCreated = null,
        //            DateUpdated = new DateTime(),
        //            UserUpdated = null,
        //        },
        //        new Prescription
        //        {
        //            Id = 7,
        //            P_ID = 3,
        //            D_ID = 5,
        //            D_Name = "Dr. Parimal Das",
        //            Symptoms = "Backpain",
        //            Medicine = "xxx",
        //            DateCreated = new DateTime(),
        //            UserCreated = null,
        //            DateUpdated = new DateTime(),
        //            UserUpdated = null,
        //        });
        //}      
        
    }
}
