using Healthcare.API.Data;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using Data.AccessLayer.Models;
using Prescription = Data.AccessLayer.Models.Prescription;
using Azure;
using Microsoft.AspNetCore.JsonPatch;
using Healthcare.API.Models;
using NuGet.Protocol;
using Global.Entity;


namespace Healthcare.API.Controllers
{
    [Route("api/Prescription")]
    [ApiController]
    public class PrescriptionAPIController : ControllerBase
    {
        private readonly ApplicationDbContext _db;
        public PrescriptionAPIController(ApplicationDbContext db)
        {
            _db = db;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<List<PrescriptionViewModel>> GetPrescriptions()
        {
            var prescription = _db.Prescription.ToList();
            List<PrescriptionViewModel> result = new List<PrescriptionViewModel>();
            result.AddRange(prescription.Select(x => new PrescriptionViewModel
            {
                Id = x.Id,
                PId = x.P_ID,
                DId = x.D_ID,
                
                DName = x.D_Name,
                Symptoms = x.Symptoms,
                Medicine = x.Medicine
            }).ToList());
            return Ok(result);
        }

        [HttpGet("Id", Name = "GetPrescription")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public ActionResult<Prescription> GetPrescription(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }
            var prescription = _db.Prescription.FirstOrDefault(u => u.Id == id);
            if (prescription == null)
            {
                return NotFound();
            }
            PrescriptionViewModel prescriptionViewModel = new PrescriptionViewModel();
            prescriptionViewModel.Id = prescription.Id;
            prescriptionViewModel.PId = prescription.P_ID;
            prescriptionViewModel.DId = prescription.D_ID;
            prescriptionViewModel.DName = prescription.D_Name;
            prescriptionViewModel.Symptoms = prescription.Symptoms;
            prescriptionViewModel.Medicine = prescription.Medicine;
            return Ok(prescriptionViewModel);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<Prescription> CreatePrescription([FromBody] Prescription prescription)
        {
            if (prescription == null)
            {
                return BadRequest(prescription);
            }
            if (prescription.Id > 0)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            //prescription.Id = PrescriptionStore.prescriptionList.OrderByDescending(u => u.Id).FirstOrDefault().Id + 1;
            //PrescriptionStore.prescriptionList.Add(prescription);

            Prescription model = new()
            {
                P_ID = prescription.P_ID,
                D_ID = prescription.D_ID,
                D_Name = prescription.D_Name,
                Symptoms = prescription.Symptoms,
                Medicine = prescription.Medicine,
                DateCreated = prescription.DateCreated,
                UserCreated = prescription.UserCreated,
                DateUpdated = prescription.DateUpdated,
                UserUpdated = prescription.UserUpdated
            };
            _db.Prescription.Add(model);
            _db.SaveChanges();
            return CreatedAtRoute("GetPrescription", new { id = prescription.Id }, prescription);
        }

        [HttpDelete("id", Name = "DeletePrescription")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult DeletePrescription(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }
            var prescription = _db.Prescription.FirstOrDefault(u => u.Id == id);
            if (prescription == null)
            {
                return NotFound();
            }
            //PrescriptionStore.prescriptionList.Remove(prescription);
            //PatientStore.patientList.SaveChanges();
            _db.Prescription.Remove(prescription);
            _db.SaveChanges();
            return NoContent();
        }

        [HttpPut("id", Name = "UpdatePrescription")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult UpdatePrescription(int id, [FromBody] Prescription prescription)
        {
            if (prescription == null || id != prescription.Id)
            {
                return BadRequest();
            }
            //var pres = PrescriptionStore.prescriptionList.FirstOrDefault(u => u.Id == id);
            //pres.PId = prescription.PId;
            //pres.DId = prescription.DId;
            //pres.DName = prescription.DName;
            //pres.Symptoms = prescription.Symptoms;
            //pres.Medicine = prescription.Medicine;
            //pres.DateCreated = prescription.DateCreated;
            //pres.UserCreated = prescription.UserCreated;
            //pres.DateUpdated = prescription.DateUpdated;
            //pres.UserUpdated = prescription.UserUpdated;
            //return NoContent();

            Prescription model = new()
            {
                P_ID = prescription.P_ID,
                D_ID = prescription.D_ID,
                D_Name = prescription.D_Name,
                Symptoms = prescription.Symptoms,
                Medicine = prescription.Medicine,
                DateCreated = prescription.DateCreated,
                UserCreated = prescription.UserCreated,
                DateUpdated = prescription.DateUpdated,
                UserUpdated = prescription.UserUpdated
            };
            _db.Prescription.Update(model);
            _db.SaveChanges();
            return NoContent();
        }

        [HttpPatch("id", Name = "UpdatePartialPrescription")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult UpdatePartialPrescription(int id, JsonPatchDocument<Prescription> patch)
        {
            if (patch == null || id == 0)
            {
                return BadRequest();
            }
            var prescription = _db.Prescription.FirstOrDefault(u => u.Id == id);

            Prescription prescription1 = new()
            {
                P_ID = prescription.P_ID,
                D_ID = prescription.D_ID,
                D_Name = prescription.D_Name,
                Symptoms = prescription.Symptoms,
                Medicine = prescription.Medicine,
                DateCreated = prescription.DateCreated,
                UserCreated = prescription.UserCreated,
                DateUpdated = prescription.DateUpdated,
                UserUpdated = prescription.UserUpdated
            };
            if (prescription == null)
            {
                return BadRequest();
            }
            patch.ApplyTo(prescription1, ModelState);
            Prescription model = new Prescription()
            {
                P_ID = prescription1.P_ID,
                D_ID = prescription1.D_ID,
                D_Name = prescription1.D_Name,
                Symptoms = prescription1.Symptoms,
                Medicine = prescription.Medicine,
                DateCreated = prescription1.DateCreated,
                UserCreated = prescription1.UserCreated,
                DateUpdated = prescription1.DateUpdated,
                UserUpdated = prescription1.UserUpdated
            };
            _db.Prescription.Update(model);
            _db.SaveChanges();

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return NoContent();
        }
    }
}
