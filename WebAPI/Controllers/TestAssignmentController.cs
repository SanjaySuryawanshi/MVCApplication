
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    public class TestAssignmentController : ApiController
    {


        // GET: api/CollegeDetails  
        public QuestionList savequestiondetails()
        {
            QuestionList ee = new QuestionList();
            ee.Question = "abcd";
            ee.QuestionType = "3";

            //ee.QuestionType = "2";
            using (DataModelDbContext dbContext = new DataModelDbContext())
            {
                 dbContext.QuestionLists.Add(ee);
                dbContext.SaveChanges();
                   }
            return ee;
        }
        public IEnumerable<QuestionList> GetQuestionList()
        {
            //List<QuestionList> employeeList = new List<QuestionList>();
            //DataModelDbContext dc = new DataModelDbContext();
           // List <QuestionList> ee = null;
            using (DataModelDbContext dc = new DataModelDbContext())
            {
                // yield return dc.QuestionLists.FirstOrDefault(e => e.QuestionType =="22");
                return dc.QuestionLists.ToList();
                // return ee;
               // yield return dc.QuestionLists.ToList();
            }
        }
    }
}
