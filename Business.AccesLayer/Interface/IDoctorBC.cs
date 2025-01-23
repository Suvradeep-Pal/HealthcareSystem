using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GE = Global.Entity;

namespace Business.AccessLayer.Interface
{
    public interface IDoctorBC
    {
        Task<List<GE::Doctor>> GetDoctors();
        Task<GE::Doctor> GetDoctorbyid(int id);
        Task<string> Save(GE::Doctor doctor);
        Task<string> RemoveDoctor(int id);
    }
}
