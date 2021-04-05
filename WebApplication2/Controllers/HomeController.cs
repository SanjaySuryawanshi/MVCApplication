using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication2.Models;
using WebAPI.Controllers;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Net;
using System.Web.Script.Serialization;
using System.Text;

namespace WebApplication2.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";
            

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult QuestionList()
        {
            ViewBag.Message = "Your Question List page.";

            return View();
        }
        [HttpPost]
        public async Task<ActionResult> SaveQuestionDetails(QuestionList2 QList)
        {
            string apiUrl = "https://localhost:44335/api/Tested";
            
            string inputJson = (new JavaScriptSerializer()).Serialize(QList);
            WebClient client = new WebClient();
            client.Headers["Content-type"] = "application/json";
            client.Encoding = Encoding.UTF8;
            string json = client.UploadString(apiUrl + "/SaveQuestionDetails", inputJson);

            return Json(new { data = json }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult loaddata()
        {
            
            //using (MyDatabaseEntities dc = new MyDatabaseEntities())
            //{
            //    var data = dc.Customers.OrderBy(a => a.ContactName).ToList();
            //    return Json(new { data = data }, JsonRequestBehavior.AllowGet);
            //}

            List<QuestionList> students = new List<QuestionList>();
            students.Add(new QuestionList
            {
                ID = 101,
                Name = "Seam",
                Email = "seam@gmail.com",
                Address = "Dhaka,Bangladesh"
            });
            students.Add(new QuestionList
            {
                ID = 102,
                Name = "Mitila",
                Email = "mitila@gmail.com",
                Address = "Dhaka,Bangladesh"
            });
            students.Add(new QuestionList
            {
                ID = 104,
                Name = "Popy",
                Email = "popy@yahoo.com",
                Address = "Dhaka,Bangladesh"
            });
            return Json(new { data = students }, JsonRequestBehavior.AllowGet);
        }
        public async Task<ActionResult> GetAPIData()
        {
            string apiUrl = "https://localhost:44335/api/Tested";
            List<QuestionList2> lst = new List<QuestionList2>();
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(apiUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.GetAsync(apiUrl);
                if (response.IsSuccessStatusCode)
                {
                    //var data2 = await response.Content.ReadAsStringAsync();
                    var EmpResponse = response.Content.ReadAsStringAsync().Result;

                    //Deserializing the response recieved from web api and storing into the Employee list  
                    lst = JsonConvert.DeserializeObject<List<QuestionList2>>(EmpResponse);
                    //var table = Newtonsoft.Json.JsonConvert.DeserializeObject<System.Data.DataTable>(data);
                    // return Json(new { data = data2 }, JsonRequestBehavior.AllowGet);
                }


            }
            //return Json(new { data  = data2 }, JsonRequestBehavior.AllowGet);
           // return View(lst);
            return Json(new { data = lst }, JsonRequestBehavior.AllowGet);
        }

    }
}