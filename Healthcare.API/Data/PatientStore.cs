//using Healthcare.API.Models;
using Patient = Data.AccessLayer.Models.Patient;

namespace Healthcare.API.Data
{
    public static class PatientStore
    {
        public static List<Patient> patientList = new List<Patient>
            {
                new Patient{Id=6, First_Name="Aman", Last_Name="Bhatt", Date_Of_Birth=new DateTime(1997,02,04), Gender="M", Address="Delhi", Phone="8894121000", DateCreated=new DateTime(), UserCreated=null, DateUpdated=new DateTime(), UserUpdated=null},
                new Patient{Id=7, First_Name="Raman", Last_Name="Gupta", Date_Of_Birth=new DateTime(1994,06,12), Gender="M", Address="Mumbai", Phone="9045889744", DateCreated=new DateTime(), UserCreated=null, DateUpdated=new DateTime(), UserUpdated=null}
            };
    }
}
