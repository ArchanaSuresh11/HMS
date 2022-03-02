using Microsoft.AspNetCore.Mvc;
using PatientMvc.Models;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace PatientMvc.Controllers
{
    public class PatientController : Controller
    {
        string Baseurl = "https://localhost:7091/";
        public async Task<IActionResult> Index()
        {
            List<PatientDetails> patientDetailss = new List<PatientDetails>();
            using (var client = new HttpClient())
            {
                client.BaseAddress=new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage res=await client.GetAsync("api/PatientDetails/GetAll");
                if(res.IsSuccessStatusCode)
                {
                    var EmpResponse=res.Content.ReadAsStringAsync().Result;
                    patientDetailss=JsonConvert.DeserializeObject<List<PatientDetails>>(EmpResponse);
                }
                return View(patientDetailss);
            }
        }

    //    Uri baseAddress = new Uri("https://localhost:7091/swagger/index.html");
    //    HttpClient client;
    //    public PatientController1()
    //    {
    //        client = new HttpClient();
    //        client.BaseAddress = baseAddress;
    //    }
    //    public ActionResult Index()
    //    {
    //        List<PatientDetails> patientDetailss=new List<PatientDetails>();
    //        //List<Department> departments=new List<Department>();
    //        //List<Doctors>doctorss=new List<Doctors>();
    //        //List<Status> statuses=new List<Status>();
    //        HttpResponseMessage response=client.GetAsync(client.BaseAddress).Result;
    //        if(response.IsSuccessStatusCode)
    //        {
    //            string data=response.Content.ReadAsStringAsync().Result;
    //            patientDetailss=JsonConvert.DeserializeObject<List<PatientDetails>>(data);
    //            //departments=JsonConvert.DeserializeObject<List<Department>>(data);
    //            //doctorss=JsonConvert.DeserializeObject<List<Doctors>>(data);
    //            //statuses=JsonConvert.DeserializeObject<List<Status>>(data);
    //        }
    //        return View(patientDetailss);
    //    }
    }
}
