using System.Collections.Generic;
using DoctorManagement.BusinessLogic.Interfaces;
using DoctorManagement.Repository.Interfaces;
using DoctorManagement.Repository.Models;

namespace DoctorManagement.BusinessLogic.Services
{
    public class DoctorService : IDoctorService
    {
        private readonly IDoctorRepository _doctorRepository;

        public DoctorService(IDoctorRepository doctorRepository)
        {
            _doctorRepository = doctorRepository;
        }

        public Doctor GetDoctorById(int doctorId)
        {
            return _doctorRepository.GetById(doctorId);
        }

        public IEnumerable<Doctor> GetAllDoctors()
        {
            return _doctorRepository.GetAll();
        }

        public Doctor GetDoctorByEmail(string email)
        {
            return _doctorRepository.GetByEmail(email);
        }

        public void RegisterDoctor(Doctor doctor)
        {
            // Add business logic for registration (e.g., password hashing)
            _doctorRepository.Add(doctor);
            _doctorRepository.Save();
        }

        public bool LoginDoctor(string email, string password)
        {
            var doctor = _doctorRepository.GetByEmail(email);
            // In a real application, you'd compare the provided password with the hashed password
            return doctor != null && doctor.Password == password;
        }

        public void UpdateDoctorProfile(Doctor doctor)
        {
            _doctorRepository.Update(doctor);
            _doctorRepository.Save();
        }

        public void SetDoctorAvailability(int doctorId, string availability)
        {
            var doctor = _doctorRepository.GetById(doctorId);
            if (doctor != null)
            {
                doctor.Availability = availability;
                _doctorRepository.Update(doctor);
                _doctorRepository.Save();
            }
        }
    }
}