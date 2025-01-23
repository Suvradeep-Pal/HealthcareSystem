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

    public class DoctorDA : IDoctorDA
    {
        private readonly HealthcareContext healthcareContext;
        public DoctorDA(HealthcareContext healthcareContext)
        {
            this.healthcareContext = healthcareContext;
        }

        public async Task<List<GE::Doctor>> GetDoctor()
        {
            var _data = await this.healthcareContext.Doctors.ToListAsync();
            List<GE::Doctor> doctors = new List<GE::Doctor>();
            if (_data != null && _data.Count > 0)
            {
                _data.ForEach(item =>
                {
                    doctors.Add(new GE::Doctor()
                    {
                        Id = item.Id,
                        FirstName = item.First_Name,
                        LastName = item.Last_Name,                       
                        Gender = item.Gender,
                        Specialization = item.Specialization,
                        DateCreated = item.DateCreated,
                        UserCreated = item.UserCreated,
                        DateUpdated = item.DateUpdated,
                        UserUpdated = item.UserUpdated
                    });
                });
            }
            return doctors;
        }

        public async Task<GE::Doctor> GetDoctorbyid(int id)
        {
            var _data = await this.healthcareContext.Doctors.FirstOrDefaultAsync(item => item.Id == id);
            GE::Doctor doctors = new GE::Doctor();
            if (_data != null)
            {

                doctors = (new GE.Doctor()
                {
                    Id = _data.Id,
                    FirstName = _data.First_Name,
                    LastName = _data.Last_Name,     
                    Gender = _data.Gender,
                    Specialization = _data.Specialization,
                   
                });

            }
            return doctors;
        }

        public async Task<string> Save(GE::Doctor doctor)
        {
            string Response = string.Empty;
            try
            {
                if (doctor.Id > 0)
                {
                    var _exist = await this.healthcareContext.Doctors.FirstOrDefaultAsync(item => item.Id == doctor.Id);
                    if (_exist != null)
                    {
                        _exist.First_Name = doctor.FirstName;
                        _exist.Last_Name = doctor.LastName;                       
                        _exist.Gender = doctor.Gender;
                        _exist.Specialization = doctor.Specialization;
                    }
                }
                else
                {
                    Doctor _doctor = new Doctor()
                    {
                        First_Name = doctor.FirstName,
                        Last_Name = doctor.LastName,                      
                        Gender = doctor.Gender,
                        Specialization = doctor.Specialization,                      
                        DateCreated = doctor.DateCreated,
                        UserCreated = doctor.UserCreated,
                        DateUpdated = doctor.DateUpdated,
                        UserUpdated = doctor.UserUpdated
                    };
                    await this.healthcareContext.Doctors.AddAsync(_doctor);
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

        public async Task<string> RemoveDoctor(int id)
        {
            var _data = await this.healthcareContext.Doctors.FirstOrDefaultAsync(item => item.Id == id);
            string Response = string.Empty;
            if (_data != null)
            {
                try
                {
                    this.healthcareContext.Doctors.Remove(_data);
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
