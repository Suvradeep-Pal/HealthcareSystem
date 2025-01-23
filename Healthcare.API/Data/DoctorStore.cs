using Doctor = Data.AccessLayer.Models.Doctor;

namespace Healthcare.API.Data
{
    public static class DoctorStore
    {
        public static List<Doctor> doctorList = new List<Doctor>
            {
                new Doctor{Id=6, First_Name="Dr. Ramesh", Last_Name="Kurral", Gender="M", Specialization="Physio", DateCreated=new DateTime(), UserCreated=null, DateUpdated=new DateTime(), UserUpdated=null},
                new Doctor{Id=7, First_Name="Dr. Goutam", Last_Name="Nath", Gender="M", Specialization="MD", DateCreated=new DateTime(), UserCreated=null, DateUpdated=new DateTime(), UserUpdated=null}
            };
    }
}
