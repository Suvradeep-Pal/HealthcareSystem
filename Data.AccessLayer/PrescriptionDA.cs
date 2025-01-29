using Data.AccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.AccessLayer.Models;
using GE = Global.Entity;
using Data.AccessLayer.Interface;
using Microsoft.EntityFrameworkCore;

namespace Data.AccessLayer
{
    public class PrescriptionDA : IPrescriptionDA
    {
        private readonly HealthcareContext healthcareContext;
        public PrescriptionDA(HealthcareContext healthcareContext)
        {
            this.healthcareContext = healthcareContext;
        }

        public async Task<List<GE::Prescription>> GetPrescription()
        {
            var _data = await this.healthcareContext.Prescriptions.ToListAsync();
            List<GE::Prescription> prescriptions = new List<GE::Prescription>();
            if (_data != null && _data.Count > 0)
            {
                _data.ForEach(item =>
                {
                    prescriptions.Add(new GE::Prescription()
                    {
                        Id = item.Id,
                        PId = item.P_ID,
                        PatientName = item.P_ID == null ? string.Empty : this.healthcareContext.Patients.SingleOrDefault(x => x.Id == item.P_ID).First_Name + " " + this.healthcareContext.Patients.SingleOrDefault(x => x.Id == item.P_ID).Last_Name,
                        DId = item.D_ID,
                        DName = item.D_Name,
                        Symptoms = item.Symptoms,
                        Medicine = item.Medicine,
                        DateCreated = item.DateCreated,
                        UserCreated = item.UserCreated,
                        DateUpdated = item.DateUpdated,
                        UserUpdated = item.UserUpdated,
                        Status = item.Status
                    });
                });
            }
            return prescriptions;
        }

        public async Task<GE::Prescription> GetPrescriptionbyid(int id)
        {
            var _data = await this.healthcareContext.Prescriptions.FirstOrDefaultAsync(item => item.Id == id);
            GE::Prescription prescription = new GE::Prescription();
            if (_data != null)
            {

                prescription = (new GE.Prescription()
                {
                    Id = _data.Id,
                    PId = _data.P_ID,
                    PatientName = _data.P_ID == null ? string.Empty : this.healthcareContext.Patients.SingleOrDefault(x => x.Id == _data.P_ID).First_Name + " " + this.healthcareContext.Patients.SingleOrDefault(x => x.Id == _data.P_ID).Last_Name,
                    DId = _data.D_ID,
                    DName = _data.D_Name,
                    Symptoms = _data.Symptoms,
                    Medicine = _data.Medicine
                });

            }
            return prescription;
        }

        public async Task<string> Save(GE::Prescription prescription)
        {
            string Response = string.Empty;
            try
            {
                if (prescription.Id > 0)
                {
                    var _exist = await this.healthcareContext.Prescriptions.FirstOrDefaultAsync(item => item.Id == prescription.Id);
                    if (_exist != null)
                    {
                        _exist.P_ID = prescription.PId;
                        
                        _exist.D_ID = prescription.DId;
                        _exist.D_Name = prescription.DName;
                        _exist.Symptoms = prescription.Symptoms;
                        _exist.Medicine = prescription.Medicine;
                        _exist.UserUpdated = 0;
                        _exist.DateUpdated = DateTime.Now;
                    }
                }
                else
                {
                    Prescription _prescription = new Prescription()
                    {
                        P_ID = prescription.PId,
                        
                        D_ID = prescription.DId,
                        D_Name = prescription.DName,
                        Symptoms = prescription.Symptoms,
                        Medicine = prescription.Medicine,
                        DateCreated = DateTime.Now,
                        UserCreated = 0,
                        DateUpdated = prescription.DateUpdated,
                        UserUpdated = prescription.UserUpdated
                    };
                    await this.healthcareContext.Prescriptions.AddAsync(_prescription);
                }
                await this.healthcareContext.SaveChangesAsync();
                Response = "pass";

            }
            catch (Exception ex)
            {
                Response = ex.Message;
            }
            return Response;
        }

        public async Task<string> RemovePrescription(int id)
        {
            var _data = await this.healthcareContext.Prescriptions.FirstOrDefaultAsync(item => item.Id == id);
            string Response = string.Empty;
            if (_data != null)
            {
                try
                {
                    //this.healthcareContext.Prescriptions.Remove(_data);
                    _data.Status = (_data.Status == false) ? true : false;
                    _data.DateUpdated = DateTime.Now;
                    _data.UserUpdated = 0;
                    await this.healthcareContext.SaveChangesAsync();
                    Response = "pass";
                }
                catch (Exception ex)
                {

                }
            }
            return Response;
        }
    }
}
