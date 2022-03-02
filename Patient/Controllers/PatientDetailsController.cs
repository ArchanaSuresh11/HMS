using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Patient.Data;
using Patient.Models;
using Patient.Repository;
using Patient.View_Model;
using System.Net;

namespace Patient.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientDetailsController : ControllerBase
    {
        private readonly IRepository _db;
        private readonly object? ObjPatientDetailsList;
        public PatientDetailsController(IRepository db)
        {
            _db = db;
        }

        [HttpGet]
        public List<PatientDetailsVM> Get()
        {
            try
            {
                var ObjPatientDetailsList = _db.Get();
                var DoctorsList = _db.DoctorA();
                var DepartmentList = _db.DepartmentB();
                var StatusList = _db.StatusC();

                var result = from b in ObjPatientDetailsList
                             join b1 in DoctorsList
                             on b.AssignedDoctor_Id equals b1.Id
                             join b2 in DepartmentList
                             on b.Department_Id equals b2.Id
                             join b3 in StatusList
                             on b.Status_Id equals b3.Id
                             select new PatientDetailsVM
                             {
                                 Patient_Id = b.Patient_Id,
                                 Name = b.Name,
                                 Age = b.Age,
                                 Gender = b.Gender,
                                 Address = b.Address,
                                 ContactNumber = b.ContactNumber,
                                 AssignedDoctor_Id = b1.Doctor_Name,
                                 Department_Id = b2.DepartmentName,
                                 Ward_Number = b.Ward_Number,
                                 Bed_Number = b.Bed_Number,
                                 Status_Id = b3.StatusName,
                             };
                return (result.ToList());
            }
            catch (Exception)
            {
                return null;
            }
        }





        [HttpPost]
        public ActionResult Create(PatientDetails obj)
        {
            try
            {
                var result = _db.Create(obj);
                return Ok("success");
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                  "Error creating new employee record");
            }
        }
        [HttpDelete("{Id}")]
        
        public async Task<ActionResult<PatientDetails>> Delete(int Id)
        {
            try
            {
                _db.Delete(Id);
                return Ok();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                   "Error in deleting data");
            }
        }
        [HttpPut]
        public async Task<ActionResult<PatientDetails>> Update(DtoPatientDetails request)
        {
            try
            {
                _db.Update(request);
                //if (PatientFromDb == null)
                //return NotFound($"Employee with Id = {Id} not found");

                return Ok();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                "Error in updating data");
            }
        }

        [HttpGet]
        [Route("{Id:int}")]
        public async Task<ActionResult<PatientDetails>> GetById(int Id)
        {
            var PatientsDb = _db.GetById(Id);
            if (PatientsDb == null)
                return BadRequest("Not Found");
            var ObjPatientDetailsList = _db.Get();
            var DoctorsList = _db.DoctorA();
            var DepartmentList = _db.DepartmentB();
            var StatusList = _db.StatusC();

            var result = from b in ObjPatientDetailsList
                         join b1 in DoctorsList
                         on b.AssignedDoctor_Id equals b1.Id
                         join b2 in DepartmentList
                         on b.Department_Id equals b2.Id
                         join b3 in StatusList
                         on b.Status_Id equals b3.Id
                         select new PatientDetailsVM
                         {
                             Patient_Id = b.Patient_Id,
                             Name = b.Name,
                             Age = b.Age,
                             Gender = b.Gender,
                             Address = b.Address,
                             ContactNumber = b.ContactNumber,
                             AssignedDoctor_Id = b1.Doctor_Name,
                             Department_Id = b2.DepartmentName,
                             Ward_Number = b.Ward_Number,
                             Bed_Number = b.Bed_Number,
                             Status_Id = b3.StatusName,

                         };
            var result1 = result.First(i => i.Patient_Id == Id);

            return Ok(result1);
        }




        [HttpGet("{Name}")]
        public async Task<ActionResult<PatientDetails>> Get(string Name)
        {

            var ObjPatientDetailsList1 = _db.Get();
            var DoctorsList1 = _db.DoctorA();
            var DepartmentList1 = _db.DepartmentB();
            var StatusList1 = _db.StatusC();
            var result = from b in ObjPatientDetailsList1
                         join b1 in DoctorsList1
                         on b.AssignedDoctor_Id equals b1.Id
                         join b2 in DepartmentList1
                         on b.Department_Id equals b2.Id
                         join b3 in StatusList1
                         on b.Status_Id equals b3.Id
                         select new { b.Patient_Id, b.Name, b.Age, b.Address, b.Gender, b.ContactNumber, b1.Doctor_Name, b2.DepartmentName, b.Ward_Number, b.Bed_Number, b3.StatusName };
            return Ok(result.FirstOrDefault(a => a.Name == Name));

        }



        [HttpGet]
        [Route("Doctors/[controller]")]
        public IActionResult GetDoctorA()
        {
            var DoctorList = _db.GetDoctorA();
            return Ok(DoctorList);
        }

        [HttpGet]
        [Route("Department/[controller]")]
        public IActionResult GetDepartmentB()
        {
            var DoctorList = _db.GetDepartmentB();
            return Ok(DoctorList);
        }


        [HttpGet]
        [Route("Status/[controller]")]
        public IActionResult GetStatusC()
        {
            var DoctorList = _db.GetStatusC();
            return Ok(DoctorList);
        }
        //[HttpPost]
        //public async Task<ActionResult<string>> Create(string obj)
        //{
        //    try
        //    {
        //        //var result = await _db.Create(obj);
        //        return Ok("success");
        //    }
        //    catch (Exception)
        //    {
        //        return StatusCode(StatusCodes.Status500InternalServerError,
        //          "Error creating new employee record");
        //    }
        //}

    }


}
