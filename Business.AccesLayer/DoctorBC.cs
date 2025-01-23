using Business.AccessLayer.Interface;
using Data.AccessLayer.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GE = Global.Entity;
using Data.AccessLayer;

namespace Business.AccessLayer
{
    public class DoctorBC : IDoctorBC
    {
        private readonly IDoctorDA doctorDA;

        public DoctorBC(IDoctorDA doctor)
        {
            this.doctorDA = doctor;
        }

        public async Task<List<GE::Doctor>> GetDoctors()
        {
            return await this.doctorDA.GetDoctor();
        }

        public async Task<GE::Doctor> GetDoctorbyid(int id)
        {
            return await this.doctorDA.GetDoctorbyid(id);
        }

        public async Task<string> Save(GE::Doctor doctor)
        {
            return await this.doctorDA.Save(doctor);
        }

        public async Task<string> RemoveDoctor(int id)
        {
            return await this.doctorDA.RemoveDoctor(id);
        }
    }
}
