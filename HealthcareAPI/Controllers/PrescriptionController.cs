using Business.AccessLayer.Interface;
using Healthcare.UI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using GE = Global.Entity;

namespace Healthcare.UI.Controllers
{
    public class PrescriptionController : Controller
    {
        private readonly IPrescriptionBC prescriptionBC;
        private readonly IDoctorBC doctorBC;
        private readonly IPatientBC patientBC;
        public PrescriptionController(IPrescriptionBC prescriptionBC, IDoctorBC doctorBC, IPatientBC patientBC)
        {
            this.prescriptionBC = prescriptionBC;
            this.doctorBC = doctorBC;
            this.patientBC = patientBC;
        }
        public async Task<IActionResult> Index()
        {
            List<GE::Prescription> prescriptions = await this.prescriptionBC.GetPrescription();
            return View(prescriptions);
        }

        public async Task<IActionResult> Create()
        {
            
            PrescriptionViewModel prescriptionViewModel = new PrescriptionViewModel();
            prescriptionViewModel.DDLDoctor = new List<SelectListItem>();
            prescriptionViewModel.DDLPatient = new List<SelectListItem>();
            List<GE::Doctor> doctors = await this.doctorBC.GetDoctors();
            prescriptionViewModel.DDLDoctor.AddRange(doctors.Select(x => new SelectListItem { Text = x.FirstName + " " + x.LastName, Value = x.Id.ToString() }).ToList());
            List<GE::Patient> patients = await this.patientBC.GetPatients();
            prescriptionViewModel.DDLPatient.AddRange(patients.Select(x => new SelectListItem { Text = x.FirstName + " " + x.LastName, Value = x.Id.ToString() }).ToList());
            return View(prescriptionViewModel);
        }

        public async Task<IActionResult> Edit(string id)
        {
            GE::Prescription prescription = await this.prescriptionBC.GetPrescriptionbyid(Convert.ToInt32(id));
            PrescriptionViewModel prescriptionViewModel = new PrescriptionViewModel();
            prescriptionViewModel.Id = prescription.Id;
            prescriptionViewModel.DId = prescription.DId;
            prescriptionViewModel.PId = prescription.PId;
            prescriptionViewModel.Medicine = prescription.Medicine;
            prescriptionViewModel.Symptoms = prescription.Symptoms;
            prescriptionViewModel.DName = prescription.DName;
            prescriptionViewModel.PatientName = prescription.PatientName;
            prescriptionViewModel.DDLDoctor = new List<SelectListItem>();
            prescriptionViewModel.DDLPatient = new List<SelectListItem>();
            List<GE::Doctor> doctors = await this.doctorBC.GetDoctors();
            prescriptionViewModel.DDLDoctor.AddRange(doctors.Select(x => new SelectListItem { Text = x.FirstName + " " + x.LastName, Value = x.Id.ToString() }).ToList());
            List<GE::Patient> patients = await this.patientBC.GetPatients();
            prescriptionViewModel.DDLPatient.AddRange(patients.Select(x => new SelectListItem { Text = x.FirstName + " " + x.LastName, Value = x.Id.ToString() }).ToList());
            return View("Create", prescriptionViewModel);
        }

        public async Task<IActionResult> Save(GE::Prescription prescription)
        {
            string Response = await this.prescriptionBC.Save(prescription);
            return Json(Response);
        }

        public async Task<IActionResult> Remove(string id)
        {
            string Response = await this.prescriptionBC.RemovePrescription(Convert.ToInt32(id));
            return Json(Response);
        }
    }
}
