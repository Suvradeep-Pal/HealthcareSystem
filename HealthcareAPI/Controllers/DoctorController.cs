using Business.AccessLayer.Interface;
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
            List<GE::Doctor> doctors = await this.doctorBC.GetDoctors();
            return View(doctors);
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

        public async Task<IActionResult> Remove(string id)
        {
            string Response = await this.doctorBC.RemoveDoctor(Convert.ToInt32(id));
            return Json(Response);
        }
    }
}
