using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GE = Global.Entity;

namespace Business.AccessLayer.Interface
{
    public interface IPatientBC
    {
        Task<List<GE::Patient>> GetPatients();
        Task<GE::Patient> GetPatientbyid(int id);
        Task<string> Save(GE::Patient patient);
        Task<string> RemovePatient(int id);
    }
}
