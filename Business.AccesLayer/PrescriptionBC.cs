using Business.AccessLayer.Interface;
using Data.AccessLayer.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GE = Global.Entity;

namespace Business.AccessLayer
{
    public class PrescriptionBC : IPrescriptionBC
    {
            private readonly IPrescriptionDA prescriptionDA;

            public PrescriptionBC(IPrescriptionDA prescription)
            {
                this.prescriptionDA = prescription;
            }

            public async Task<List<GE::Prescription>> GetPrescription()
            {
                
                return await this.prescriptionDA.GetPrescription();
            }

            public async Task<GE::Prescription> GetPrescriptionbyid(int id)
            {
                return await this.prescriptionDA.GetPrescriptionbyid(id);
            }

            public async Task<string> Save(GE::Prescription prescription)
            {
                return await this.prescriptionDA.Save(prescription);
            }

            public async Task<string> RemovePrescription(int id)
            {
                return await this.prescriptionDA.RemovePrescription(id);
            }

    }
}
