using Microsoft.AspNetCore.Mvc;
using DoctorManagement.BusinessLogic.Interfaces;
using DoctorManagement.Repository.Models;

namespace DoctorManagement.Controllers
{
    public class DoctorController : Controller
    {
        private readonly IDoctorService _doctorService;

        public DoctorController(IDoctorService doctorService)
        {
            _doctorService = doctorService;
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(Doctor model)
        {
            if (ModelState.IsValid)
            {
                _doctorService.RegisterDoctor(model);
                return RedirectToAction("Login");
            }
            return View(model);
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string email, string password)
        {
            if (_doctorService.LoginDoctor(email, password))
            {
                // In a real application, you'd use authentication cookies
                var doctor = _doctorService.GetDoctorByEmail(email);
                if (doctor != null)
                {
                    return RedirectToAction("Dashboard", new { doctorId = doctor.DoctorId });
                }
            }
            ModelState.AddModelError(string.Empty, "Invalid login attempt.");
            return View();
        }

        public IActionResult Dashboard(int doctorId)
        {
            var doctor = _doctorService.GetDoctorById(doctorId);
            if (doctor == null)
            {
                return NotFound();
            }
            return View(doctor);
        }

        public IActionResult EditProfile(int doctorId)
        {
            var doctor = _doctorService.GetDoctorById(doctorId);
            if (doctor == null)
            {
                return NotFound();
            }
            return View(doctor);
        }

        [HttpPost]
        public IActionResult EditProfile(Doctor model)
        {
            if (ModelState.IsValid)
            {
                _doctorService.UpdateDoctorProfile(model);
                return RedirectToAction("Dashboard", new { doctorId = model.DoctorId });
            }
            return View(model);
        }

        public IActionResult SetAvailability(int doctorId)
        {
            var doctor = _doctorService.GetDoctorById(doctorId);
            if (doctor == null)
            {
                return NotFound();
            }
            return View(doctor);
        }

        [HttpPost]
        public IActionResult SetAvailability(int doctorId, string availability)
        {
            _doctorService.SetDoctorAvailability(doctorId, availability);
            return RedirectToAction("Dashboard", new { doctorId });
        }
    }
}