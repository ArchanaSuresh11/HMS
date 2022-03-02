using Patient.Models;
using Patient.View_Model;

namespace Patient.Repository
{
    public interface IRepository
    {
        List<PatientDetails>Get();
        List<Doctors> DoctorA();
        List<Department> DepartmentB();
        List<Status> StatusC();
        Task<PatientDetails> Create(PatientDetails obj);
        void Delete(int Id);
        Task<PatientDetails> Update(DtoPatientDetails request);
        Task<PatientDetails> GetById(int Id);
        Task<PatientDetails> Get(string Name);
        List<Doctors> GetDoctorA();
        List<Department> GetDepartmentB();
        List<Status> GetStatusC();
    }
}
