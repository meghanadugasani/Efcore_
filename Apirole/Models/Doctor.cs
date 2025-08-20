using System.ComponentModel.DataAnnotations;

namespace Apiauth.Models
{
    public class Doctor
    {
        [Key]
        public int DoctorId { get; set; }

        [Required] 
        public string? Doctorname { get; set; } 

        public string? Specialization { get; set; } 

        public string? Phone { get; set; } 
        public string? Email { get; set; } 
    }
}
