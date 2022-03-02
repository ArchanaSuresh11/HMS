using Patient.Data;
using Patient.Models;
using Patient.View_Model;

namespace Patient.Repository
{
    public class Repository : IRepository
    {
        private readonly ApplicationDbContext _db;
        public Repository(ApplicationDbContext db)
        {
            _db = db;
            
        }
        public async Task<PatientDetails> Create(PatientDetails obj)
        {
            var result = _db.PatientDetailss.Add(obj);
            _db.SaveChanges();
            return result.Entity;
        }

        public void Delete(int Id)
        {
            var PatientDb = _db.PatientDetailss.Find(Id);
            _db.PatientDetailss.Remove(PatientDb);
            _db.SaveChanges();

        }

        public List<PatientDetails> Get()
        {
            var ObjPatientDetailsList = _db.PatientDetailss.ToList();
            return ObjPatientDetailsList;
        }
        public List<Doctors>DoctorA()
        {
            var DoctorsList = _db.DoctorNames.ToList();
            return DoctorsList;
        }
        public List<Department> DepartmentB()
        {
            var DepartmentList = _db.Departments.ToList();
            return DepartmentList;
        }
        public List<Status> StatusC()
        {
            var StatusList = _db.Statuses.ToList();
            return StatusList;
        }
        public async Task<PatientDetails> Get(string Name)
        {
            var results = _db.PatientDetailss.FirstOrDefault(m => m.Name == Name);
            return results;
        }

        public async Task<PatientDetails> GetById(int Id)
        {
            var PatientsDb = _db.PatientDetailss.Find(Id);

            //var result1 = result.First(i => i.Patient_Id == Id);

            return PatientsDb;
        }

        public async Task<PatientDetails> Update(DtoPatientDetails request)
        {
            var PatientFromDb = _db.PatientDetailss.Find(request.Patient_Id);
            PatientFromDb.Name = request.Name;
            PatientFromDb.Age = request.Age;
            PatientFromDb.ContactNumber = request.ContactNumber;
            PatientFromDb.Department_Id = request.Department_Id;
            PatientFromDb.AssignedDoctor_Id = request.AssignedDoctor_Id;
            PatientFromDb.Address = request.Address;
            PatientFromDb.Status_Id = request.Status_Id;
            _db.PatientDetailss.Update(PatientFromDb);
            _db.SaveChanges();
            return PatientFromDb;
        }
        public List<Doctors>GetDoctorA()
        {
            var DoctorList = _db.DoctorNames.ToList();
            return DoctorList;
        }
        public List<Department> GetDepartmentB()
        {
            var DoctorList = _db.Departments.ToList();
            return DoctorList;
        }
        public List<Status> GetStatusC()
        {
            var DoctorList = _db.Statuses.ToList();
            return DoctorList;
        }
    }
}
