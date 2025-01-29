using Business.AccessLayer.Interface;
using Healthcare.UI.Models;
using Microsoft.AspNetCore.Mvc;
using GE = Global.Entity;

namespace Healthcare.UI.Controllers
{
    public class DoctorController : Controller
    {
        private readonly IDoctorBC doctorBC;
        public DoctorController(IDoctorBC doctorBC)
        {
            this.doctorBC = doctorBC;
        }
        public async Task<IActionResult> Index()
        {
            //List<GE::Doctor> doctors = await this.doctorBC.GetDoctors();
            DoctorSearchViewModel doctor = new DoctorSearchViewModel();
            doctor.doctors = new List<GE::Doctor>();
            doctor.doctors = await this.doctorBC.GetDoctors();
            doctor.doctors = doctor.doctors.Where(p => p.Status == true).OrderBy(a => a.FirstName).ToList();
            return View(doctor);
        }

        public IActionResult Create()
        {
            return View(new GE.Doctor());
        }

        public async Task<IActionResult> Edit(string id)
        {
            GE::Doctor doctors = await this.doctorBC.GetDoctorbyid(Convert.ToInt32(id));
            return View("Create", doctors);
        }

        public async Task<IActionResult> Save(GE::Doctor doctor)
        {
            string Response = await this.doctorBC.Save(doctor);
            return Json(Response);
        }

        [HttpPost]

        public async Task<IActionResult> Index(DoctorSearchViewModel doctor)
        {
            doctor.doctors = this.doctorBC.GetDoctors().Result.OrderBy(a => a.FirstName).ToList();

            if (!string.IsNullOrWhiteSpace(doctor.Name))
            {
                doctor.doctors = doctor.doctors.Where(x => x.FirstName.ToLower().Trim().Contains(doctor.Name.ToLower().Trim()) || x.LastName.ToLower().Trim().Contains(doctor.Name.ToLower().Trim())).ToList();
            }

            if (doctor.Status != null && doctor.Status != false)
            {
                doctor.doctors = doctor.doctors.Where(p => p.Status == true).ToList();
            }
            return View(doctor);
        }

        public async Task<IActionResult> Remove(string id)
        {

            string Response = await this.doctorBC.RemoveDoctor(Convert.ToInt32(id));
            return Json(Response);
        }
    }
}
