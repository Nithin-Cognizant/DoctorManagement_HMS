using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DoctorManagement.Repository.Models
{
    public class Doctor
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int DoctorId { get; set; }

        [Required]
        public string FullName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; } // Remember to hash this in a real application

        public string PhoneNumber { get; set; }

        public string Specialty { get; set; }

        public string Qualification { get; set; }

        public int ExperienceYears { get; set; }

        public string Availability { get; set; }
    }
}