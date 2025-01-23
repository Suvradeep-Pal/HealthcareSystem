using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GE = Global.Entity;

namespace Data.AccessLayer.Interface
{
    public interface IPrescriptionDA
    {
        Task<List<GE::Prescription>> GetPrescription();
        Task<GE::Prescription> GetPrescriptionbyid(int id);
        Task<string> Save(GE::Prescription prescription);
        Task<string> RemovePrescription(int id);
    }
}
