namespace Patient.View_Model
{
    public class DtoPatientDetails
    {
        public int Patient_Id { get; set; }
        public string? Name { get; set; }
        public int Age { get; set; }
        public double ContactNumber { get; set; }
        public string? Address { get; set; }
        public int Department_Id { get; set; }
        public int AssignedDoctor_Id { get; set; }
        public int Status_Id { get; set; }
    }
}
