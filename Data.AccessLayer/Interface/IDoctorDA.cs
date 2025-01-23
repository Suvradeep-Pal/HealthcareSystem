using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GE = Global.Entity;

namespace Data.AccessLayer.Interface
{
    public interface IDoctorDA
    {
        Task<List<GE::Doctor>> GetDoctor();
        Task<GE::Doctor> GetDoctorbyid(int id);
        Task<string> Save(GE::Doctor doctor);
        Task<string> RemoveDoctor(int id);
    }
}
