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
            //List<GE::Prescription> prescriptions = await this.prescriptionBC.GetPrescription();
            PrescriptionSearchViewModel prescription = new PrescriptionSearchViewModel();
            prescription.prescriptions = new List<GE::Prescription>();
            prescription.prescriptions = await this.prescriptionBC.GetPrescription();
            prescription.prescriptions = prescription.prescriptions.Where(p => p.Status == true).OrderBy(a => a.Medicine).ToList();
            return View(prescription);
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

        [HttpPost]

        public async Task<IActionResult> Index(PrescriptionSearchViewModel prescription)
        {
            prescription.prescriptions = this.prescriptionBC.GetPrescription().Result.OrderBy(a => a.Medicine).ToList();

            if (!string.IsNullOrWhiteSpace(prescription.Name))
            {
                prescription.prescriptions = prescription.prescriptions.Where(x => x.Medicine.ToLower().Trim().Contains(prescription.Name.ToLower().Trim())).ToList();
            }

            if (prescription.Status != null && prescription.Status != false)
            {
                prescription.prescriptions = prescription.prescriptions.Where(p => p.Status == true).ToList();
            }
            return View(prescription);
        }


        public async Task<IActionResult> Remove(string id)
        {
            string Response = await this.prescriptionBC.RemovePrescription(Convert.ToInt32(id));
            return Json(Response);
        }
    }
}
