using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GE = Global.Entity;

namespace Data.AccessLayer.Interface
{
    public interface IPatientDA
    {
        Task<List<GE::Patient>> GetPatient();
        Task<GE::Patient> GetPatientbyid(int id);
        Task<string> Save(GE::Patient patient);
        Task<string> RemovePatient(int id);
    }
}
