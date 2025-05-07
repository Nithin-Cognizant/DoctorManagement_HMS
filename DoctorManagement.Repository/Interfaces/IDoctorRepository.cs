using System.Collections.Generic;
using DoctorManagement.Repository.Models;

namespace DoctorManagement.Repository.Interfaces
{
    public interface IDoctorRepository
    {
        Doctor GetById(int doctorId);
        IEnumerable<Doctor> GetAll();
        Doctor GetByEmail(string email);
        void Add(Doctor doctor);
        void Update(Doctor doctor);
        void Delete(int doctorId);
        void Save();
    }
}