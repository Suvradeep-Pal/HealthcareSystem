using Data.AccessLayer.Interface;
using Data.AccessLayer.Models;
using Microsoft.EntityFrameworkCore;
using GE = Global.Entity;

namespace Data.AccessLayer
{
    public class PatientDA:IPatientDA
    {
        private readonly HealthcareContext healthcareContext;
        public PatientDA(HealthcareContext healthcareContext)
        {
            this.healthcareContext = healthcareContext;
        }

        public async Task<List<GE:: Patient>> GetPatient()
        {
            var _data = await this.healthcareContext.Patients.ToListAsync();
            List<GE:: Patient> patients =new List<GE:: Patient>();
            if(_data != null && _data.Count > 0)
            {
                _data.ForEach(item =>
                {
                    patients.Add(new GE::Patient()
                    {
                        Id = item.Id,
                        FirstName = item.First_Name,
                        LastName = item.Last_Name,
                        DateOfBirth = item.Date_Of_Birth,
                        Gender = item.Gender,
                        Address = item.Address,
                        Phone = item.Phone,
                        DateCreated = item.DateCreated,
                        UserCreated = item.UserCreated,
                        DateUpdated = item.DateUpdated,
                        UserUpdated = item.UserUpdated
                    });
                });
            }
            return patients;
        }

        public async Task<GE::Patient> GetPatientbyid(int id)
        {
            var _data = await this.healthcareContext.Patients.FirstOrDefaultAsync(item => item.Id == id);
            GE::Patient patients = new GE::Patient();
            if (_data != null)
            {

                patients = (new GE.Patient()
                {
                    Id = _data.Id,
                    FirstName = _data.First_Name,
                    LastName = _data.Last_Name,
                    DateOfBirth = _data.Date_Of_Birth,
                    Gender = _data.Gender,
                    Address = _data.Address,
                    Phone = _data.Phone
                });

            }
            return patients;
        }

        public async Task<string> Save(GE::Patient patient)
        {
            string Response = string.Empty;
            try
            {
                if (patient.Id > 0)
                {
                    var _exist = await this.healthcareContext.Patients.FirstOrDefaultAsync(item => item.Id == patient.Id);
                    if (_exist != null)
                    {
                        _exist.First_Name = patient.FirstName;
                        _exist.Last_Name = patient.LastName;
                        _exist.Date_Of_Birth = patient.DateOfBirth;
                        _exist.Gender = patient.Gender;
                        _exist.Address = patient.Address;
                        _exist.Phone = patient.Phone;
                    }
                }
                else
                {
                    Patient _patient = new Patient()
                    {
                        First_Name = patient.FirstName,
                        Last_Name = patient.LastName,
                        Date_Of_Birth = patient.DateOfBirth,
                        Gender = patient.Gender,
                        Address = patient.Address,
                        Phone = patient.Phone,
                        DateCreated = patient.DateCreated,
                        UserCreated = patient.UserCreated,
                        DateUpdated = patient.DateUpdated,
                        UserUpdated = patient.UserUpdated
                    };
                    await this.healthcareContext.Patients.AddAsync(_patient);
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

        public async Task<string> RemovePatient(int id)
        {
            var _data = await this.healthcareContext.Patients.FirstOrDefaultAsync(item => item.Id == id);
            string Response = string.Empty;
            if (_data != null)
            {
                try
                {
                    this.healthcareContext.Patients.Remove(_data);
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
