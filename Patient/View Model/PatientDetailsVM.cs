using System.ComponentModel;

namespace Patient.View_Model
{
    public class PatientDetailsVM
    {
        public int Patient_Id { get; set; }
        public string? Name { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        public double ContactNumber { get; set; }
        public string Address { get; set; }
        public string Department_Id { get; set; }
        public string AssignedDoctor_Id { get; set; }
        public int Ward_Number { get; set; }
        public int Bed_Number { get; set; }     
        public string Status_Id { get; set; }
    }
}
