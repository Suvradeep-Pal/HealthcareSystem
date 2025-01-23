using Microsoft.AspNetCore.Mvc;
using Business.AccesLayer;
using GE = Global.Entity;
using Business.AccessLayer.Interface;
using Global.Entity;

namespace HealthcareAPI.Controllers
{
    public class PatientController : Controller
    {
        private readonly IPatientBC patientBC;
        public PatientController(IPatientBC patientBC)
        {
            this.patientBC = patientBC;
        }
        public async Task<IActionResult> Index()
        {
            List<GE::Patient> patients = await this.patientBC.GetPatients();
            return View(patients);
        }

        

        public IActionResult Create()
        {
            return View(new GE.Patient());
        }

        public async Task<IActionResult> Edit(string id)
        {
            GE::Patient patients = await this.patientBC.GetPatientbyid(Convert.ToInt32(id));
            return View("Create",patients);
        }

        public async Task<IActionResult> Save(GE::Patient patient)
        {
            string Response = await this.patientBC.Save(patient);
            return Json(Response);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index(Patient patient)
        {
            if (!ModelState.IsValid)
            {
                
            }
            return View();
        }

        public async Task<IActionResult> Remove(string id)
        {
            string Response = await this.patientBC.RemovePatient(Convert.ToInt32(id));
            return Json(Response);
        }
    }

}
