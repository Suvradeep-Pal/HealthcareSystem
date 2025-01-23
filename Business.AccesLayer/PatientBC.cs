using Business.AccessLayer.Interface;
using Data.AccessLayer;
using Data.AccessLayer.Interface;
using GE = Global.Entity;

namespace Business.AccesLayer
{
    public class PatientBC : IPatientBC
    {
        private readonly IPatientDA patientDA;

        public PatientBC(IPatientDA patient)
        {
            this.patientDA = patient;
        }
        
        public async Task<List<GE::Patient>> GetPatients()
        {
            return await this.patientDA.GetPatient();
        }

        public async Task<GE::Patient> GetPatientbyid(int id)
        {
            return await this.patientDA.GetPatientbyid(id);
        }

        public async Task<string> Save(GE::Patient patient)
        {
            return await this.patientDA.Save(patient);
        }

        public async Task<string> RemovePatient(int id)
        {
            return await this.patientDA.RemovePatient(id);
        }
    }
}
