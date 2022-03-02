using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
namespace Patient.Models
{
    public class PatientDetails
    {
        [Key]
        public int Patient_Id { get; set; }
        [Required]
        public string? Name { get; set; }
        [Required]
        public int Age { get; set; }
        [Required]
        public string Gender { get; set; }
        [Required]
        [DisplayName("Contact Number ")]
        public double ContactNumber { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        [DisplayName("Department")]
        public int Department_Id { get; set; }
        [Required]
        [DisplayName("Doctor")]
        public int AssignedDoctor_Id { get; set; }
        [Required]
        [DisplayName("Ward Number")]
        public int Ward_Number { get; set; }
        [Required]
        [DisplayName("Bed Number")]
        public int Bed_Number { get; set; }
        [Required]
        [DisplayName("Status")]
        public int Status_Id { get; set; }
    }
}
