using Healthcare.API.Data;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using Data.AccessLayer.Models;
using Patient = Data.AccessLayer.Models.Patient;
using Azure;
using Microsoft.AspNetCore.JsonPatch;
using Global.Entity;
using Healthcare.API.Models;

namespace Healthcare.API.Controllers
{
    [Route("api/Patient")]
    [ApiController]
    public class PatientAPIController : ControllerBase
    {
        private readonly ApplicationDbContext _db;
        public PatientAPIController(ApplicationDbContext db)
        {
            _db = db;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<List<PatientViewModel>> GetPatients()
        {

            var patient = _db.Patients.ToList();
            List<PatientViewModel> result = new List<PatientViewModel>();
            result.AddRange(patient.Select(x => new PatientViewModel
            {
                FirstName = x.First_Name,
                LastName = x.Last_Name,
                Gender = x.Gender,
                Id = x.Id,
                DateOfBirth = x.Date_Of_Birth,
                Address = x.Address,
                Phone = x.Phone
            }).ToList());
            return Ok(result);
        }

        [HttpGet("Id", Name = "GetPatient")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public ActionResult<Patient> GetPatient(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }
            var patient = _db.Patients.FirstOrDefault(u => u.Id == id);
            if (patient == null)
            {
                return NotFound();
            }
            PatientViewModel patientViewModel = new PatientViewModel();
            patientViewModel.Id = patient.Id;
            patientViewModel.FirstName = patient.First_Name;
            patientViewModel.LastName = patient.Last_Name;
            patientViewModel.Gender = patient.Gender;
            patientViewModel.Address = patient.Address;
            patientViewModel.Phone = patient.Phone;
            patientViewModel.DateOfBirth = patient.Date_Of_Birth;
            return Ok(patientViewModel);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<PatientViewModel> CreatePatient([FromBody] PatientViewModel patient)
        {
            if (patient == null)
            {
                return BadRequest(patient);
            }
            if (patient.Id > 0)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

            Patient model = new()
            {
                First_Name = patient.FirstName,
                Last_Name = patient.LastName,
                Date_Of_Birth = patient.DateOfBirth,
                Gender = patient.Gender,
                Address = patient.Address,
                Phone = patient.Phone,
                DateCreated = DateTime.Now,
                UserCreated = 0
               
            };
            _db.Patients.Add(model);
            _db.SaveChanges();
            return CreatedAtRoute("GetPatient", new { id = patient.Id }, patient);
        }

        [HttpDelete("id", Name = "DeletePatient")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult DeletePatient(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }
            var patient = _db.Patients.FirstOrDefault(u => u.Id == id);
            if (patient == null)
            {
                return NotFound();
            }
            
            _db.Patients.Remove(patient);
            _db.SaveChanges();
            return NoContent();
        }

        [HttpPut("id", Name = "UpdatePatient")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult UpdatePatient(int id, [FromBody] PatientViewModel patient)
        {
            if (patient == null || id != patient.Id)
            {
                BadRequest();
            }

            Patient model = new()
            {
                Id = patient.Id,
                First_Name = patient.FirstName,
                Last_Name = patient.LastName,
                Date_Of_Birth = patient.DateOfBirth,
                Gender = patient.Gender,
                Address = patient.Address,
                Phone = patient.Phone,
                DateUpdated = DateTime.Now,
                UserUpdated = 0
            };
            _db.Patients.Update(model);
            _db.SaveChanges();
            return NoContent();
        }


    }
}
