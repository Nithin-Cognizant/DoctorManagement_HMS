using DoctorManagement.Repository.Models;

namespace DoctorManagement.BusinessLogic.Interfaces
{
    public interface IDoctorService
    {
        Doctor GetDoctorById(int doctorId);
        IEnumerable<Doctor> GetAllDoctors();
        Doctor GetDoctorByEmail(string email);
        void RegisterDoctor(Doctor doctor);
        bool LoginDoctor(string email, string password);
        void UpdateDoctorProfile(Doctor doctor);
        void SetDoctorAvailability(int doctorId, string availability);
        // Add other service methods as needed
    }
}