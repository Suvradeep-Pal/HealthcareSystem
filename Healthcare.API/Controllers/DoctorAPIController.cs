using Healthcare.API.Data;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using Data.AccessLayer.Models;
using Doctor = Data.AccessLayer.Models.Doctor;
using Azure;
using Microsoft.AspNetCore.JsonPatch;
using Global.Entity;
using Healthcare.API.Models;

namespace Healthcare.API.Controllers
{
    [Route("api/Doctor")]
    [ApiController]
    public class DoctorAPIController : ControllerBase
    {
        private readonly ApplicationDbContext _db;
        public DoctorAPIController(ApplicationDbContext db)
        {
            _db = db;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<List<DoctorViewModel>> GetDoctors()
        {
            var doctor = _db.Doctors.ToList();
            List<DoctorViewModel> result = new List<DoctorViewModel>();
            result.AddRange(doctor.Select(x => new DoctorViewModel { FirstName = x.First_Name, LastName = x.Last_Name, Gender = x.Gender,
                Id = x.Id, Specialization = x.Specialization }).ToList());
            return Ok(result);
        }

        [HttpGet("Id", Name = "GetDoctor")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public ActionResult<Doctor> GetDoctor(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }
            var doctor = _db.Doctors.FirstOrDefault(u => u.Id == id);
            if (doctor == null)
            {
                return NotFound();
            }
            DoctorViewModel doctorViewModel = new DoctorViewModel();
            doctorViewModel.Id = doctor.Id;
            doctorViewModel.FirstName = doctor.First_Name;
            doctorViewModel.LastName = doctor.Last_Name;
            doctorViewModel.Gender = doctor.Gender;
            doctorViewModel.Specialization = doctor.Specialization;
            return Ok(doctorViewModel);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<DoctorViewModel> CreateDoctor([FromBody] DoctorViewModel doctor)
        {
            if (doctor == null)
            {
                return BadRequest(doctor);
            }
            if (doctor.Id > 0)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            

            Doctor model = new()
            {
                First_Name = doctor.FirstName,
                Last_Name = doctor.LastName,              
                Gender = doctor.Gender,
                Specialization = doctor.Specialization,
                DateCreated =DateTime.Now,
                UserCreated = 0
                
            };
            _db.Doctors.Add(model);
            _db.SaveChanges();
            return CreatedAtRoute("GetDoctor", new { id = doctor.Id }, doctor);
        }

        [HttpDelete("id", Name = "DeleteDoctor")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult DeleteDoctor(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }
            var doctor = _db.Doctors.FirstOrDefault(u => u.Id == id);
            if (doctor == null)
            {
                return NotFound();
            }
          
            _db.Doctors.Remove(doctor);
            _db.SaveChanges();
            return NoContent();
        }

        [HttpPut("id", Name = "UpdateDoctor")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult UpdateDoctor([FromBody] DoctorViewModel doctor)
        {
            if (doctor == null)
            {
                return BadRequest();
            }

            Doctor model = new()
            {
                Id = doctor.Id,
                First_Name = doctor.FirstName,
                Last_Name = doctor.LastName,
                Gender = doctor.Gender,
                Specialization = doctor.Specialization,                
                DateUpdated = DateTime.Now,
                UserUpdated = 0
            };   
            _db.Doctors.Update(model);
            _db.SaveChanges();
            return NoContent();
        }

        
    }
}
