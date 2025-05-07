using Microsoft.EntityFrameworkCore;
using DoctorManagement.Repository.Models;

namespace DoctorManagement.Repository
{
    public class DoctorManagementDbContext : DbContext
    {
        public DoctorManagementDbContext(DbContextOptions<DoctorManagementDbContext> options) : base(options)
        {
        }

        public DbSet<Doctor> Doctors { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Doctor>()
                .HasIndex(d => d.Email)
                .IsUnique();
        }
    }
}