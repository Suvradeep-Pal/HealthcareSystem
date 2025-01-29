using Microsoft.AspNetCore.Mvc;
using Business.AccesLayer;
using GE = Global.Entity;
using Business.AccessLayer.Interface;
using Global.Entity;
using Healthcare.UI.Models;

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
            PatientSearchViewModel patient = new PatientSearchViewModel();
            patient.patients = new List<Patient>();
            patient.patients = await this.patientBC.GetPatients();
            patient.patients = patient.patients.Where(p => p.Status == true).OrderBy(a => a.FirstName).ToList();
            return View(patient);
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
        
        public async Task<IActionResult> Index(PatientSearchViewModel patient)
        {
            patient.patients = this.patientBC.GetPatients().Result.OrderBy(a => a.FirstName).ToList();

            if (!string.IsNullOrWhiteSpace(patient.Name))
            {
                patient.patients = patient.patients.Where(x => x.FirstName.ToLower().Trim().Contains(patient.Name.ToLower().Trim()) || x.LastName.ToLower().Trim().Contains(patient.Name.ToLower().Trim())).ToList();
            }
           
            if(patient.Status != null && patient.Status != false)
            {
                patient.patients = patient.patients.Where(p =>  p.Status == true).ToList();
            }
            return View(patient);
        }

        public async Task<IActionResult> Remove(string id)
        {
            string Response = await this.patientBC.RemovePatient(Convert.ToInt32(id));
            return Json(Response);
        }
    }

}
