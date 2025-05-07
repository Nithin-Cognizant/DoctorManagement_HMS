using System.Collections.Generic;
using System.Linq;
using DoctorManagement.Repository.Interfaces;
using DoctorManagement.Repository.Models;

namespace DoctorManagement.Repository.Repositories
{
    public class DoctorRepository : IDoctorRepository
    {
        private readonly DoctorManagementDbContext _dbContext;

        public DoctorRepository(DoctorManagementDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Doctor GetById(int doctorId)
        {
            return _dbContext.Doctors.Find(doctorId);
        }

        public IEnumerable<Doctor> GetAll()
        {
            return _dbContext.Doctors.ToList();
        }

        public Doctor GetByEmail(string email)
        {
            return _dbContext.Doctors.FirstOrDefault(d => d.Email == email);
        }

        public void Add(Doctor doctor)
        {
            _dbContext.Doctors.Add(doctor);
        }

        public void Update(Doctor doctor)
        {
            _dbContext.Doctors.Update(doctor);
        }

        public void Delete(int doctorId)
        {
            var doctor = _dbContext.Doctors.Find(doctorId);
            if (doctor != null)
            {
                _dbContext.Doctors.Remove(doctor);
            }
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }
    }
}