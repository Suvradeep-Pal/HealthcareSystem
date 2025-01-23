using Data.AccessLayer.Models;
using Prescription = Data.AccessLayer.Models.Prescription;

namespace Healthcare.API.Data
{
    public class PrescriptionStore
    {
        public static List<Prescription> prescriptionList = new List<Prescription>
            {
                new Prescription{Id=6, P_ID=3, D_ID=3, D_Name="Dr. Sangita Chowdhury", Symptoms="Gyano", Medicine="zzzz", DateCreated=new DateTime(), UserCreated=null, DateUpdated=new DateTime(), UserUpdated=null},
                new Prescription{Id=7, P_ID=3, D_ID=5, D_Name="Dr. Parimal Das", Symptoms="Backpain", Medicine="xxx", DateCreated=new DateTime(), UserCreated=null, DateUpdated=new DateTime(), UserUpdated=null}
            };
    }
}
